using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using FinanceServ.Common.Swagger;
using AutoMapper;
using FinanceServ.Services.Interfaces;
using FinanceServ.Models.DTO;
using FinanceServ.Models.Requests.User;
using FinanceServ.Models.Responses.User;
using FinanceServ.Infrastructure;
using FinanceServ.Infrastructure.Interfaces;
using FinanceServ.Controllers.Request_Response;

namespace FinanceServ.Controllers
{
    /// <summary>
    /// Контроллер для работы с пользовательскими аккаунтами.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    //[ApiExplorerSettings(GroupName = SwaggerDocParts.Account)]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;
        private readonly IJwtAuthManager _jwtAuthManager;

        /// <summary>
        /// Инициализирует экземпляр <see cref="AccountController"/>.
        /// </summary>
        /// <param name="userService">Сервис работы с пользователями.</param>
        /// <param name="logger">Логгер.</param>
        /// <param name="jwtAuthManager">Менеджер авторизации.</param>
        public AccountController(IUserService userService, ILogger<AccountController> logger, IJwtAuthManager jwtAuthManager)
        {
            _userService = userService;
            _logger = logger;
            _jwtAuthManager = jwtAuthManager;
        }

        /// <summary>
        /// Login endpoint.
        /// </summary>
        /// <param name="request">Login request <see cref="LoginRequest">.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResult))]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isUserCredentialsValid = await _userService.IsValidUserCredentialsAsync(request.Email, request.Password);

            if (!isUserCredentialsValid)
            {
                return Unauthorized();
            }

            var userRole = await _userService.GetUserRoleAsync(request.Email);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, request.Email),
                new Claim(ClaimTypes.Role, userRole)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.Email, claims, DateTime.Now);

            _logger.LogInformation($"User [{request.Email}] logged in the system.");

            return Ok(new LoginResult
            { 
                Email = request.Email,
                Role = userRole,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }

        /// <summary>
        /// Получение текущего пользователя.
        /// </summary>
        /// <returns><see cref="LoginResult"/></returns>
        [HttpGet("user")]
        [Authorize]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResult))]
        public ActionResult GetCurrentUser()
        {
            return Ok(new LoginResult
            {
                Email = User.FindFirst(ClaimTypes.Email).Value,
                Role = User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty
            });
        }

        /// <summary>
        /// Выход из системы.
        /// </summary>
        /// <returns>OkResult.</returns>
        [HttpPost("logout")]
        [Authorize]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Logout()
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;
            _jwtAuthManager.RemoveRefreshTokenByUserEmail(email);
            _logger.LogInformation($"User [{email}]) logged out the system.");
            return Ok();
        }

        /// <summary>
        /// Обновление RefreshToken.
        /// </summary>
        /// <param name="request"><see cref="RefreshTokenRequest"/>.</param>
        /// <returns><see cref="LoginResult"/>.</returns>
        [HttpPost("refresh-token")]
        [Authorize]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                _logger.LogInformation($"User [{email}] is trying to refresh JWT token");

                if (string.IsNullOrWhiteSpace(request.RefreshToken))
                {
                    return Unauthorized();
                }

                var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");
                var jwtResult = _jwtAuthManager.Refresh(request.RefreshToken, accessToken, DateTime.Now);
                _logger.LogInformation($"User [{email}] has refreshed JWT token");

                return Ok(new LoginResult
                {
                    Email = email,
                    Role = User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty,
                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                });
            }
            catch (SecurityTokenException e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}

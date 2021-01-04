using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinanceServ.Common.Swagger;
using AutoMapper;
using Microsoft.Extensions.Logging;
using FinanceServ.Services.Interfaces;
using FinanceServ.Models.DTO;
using FinanceServ.Models.Requests.User;
using FinanceServ.Models.Responses.User;

namespace FinanceServ.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными о пользователях.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="UserController"/>.
        /// </summary>
        /// <param name="userService">Сервис работы с пользователями.</param>
        /// <param name="logger">Логгер.</param>
        /// <param name="mapper">Маппер.</param>
        public UserController(IUserService userService, ILogger<UserController> logger, IMapper mapper)
        {
            _userService = userService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка пользователей системы.
        /// </summary>
        /// <returns>Коллекция сущностей "Пользователь".</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserResponse>))]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Users/GetAsync was requested.");
            var response = await _userService.GetAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<UserResponse>>(response));
        }

        /// <summary>
        /// Получение пользователя по Id.
        /// </summary>
        /// <returns>Сущность "Пользователь".</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Users/GetByIdAsync was requested.");
            var response = await _userService.GetAsync(id, cancellationToken);
            return Ok(_mapper.Map<UserResponse>(response));
        }

        /// <summary>
        /// Добавление сущности "Пользователь".
        /// </summary>
        /// <param name="request">Экземпляр <see cref="CreateUserRequest"/>.</param>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <returns>Сущность "Пользователь".</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Users/PostAsync was requested.");
            var response = await _userService.CreateAsync(_mapper.Map<UserDto>(request));
            return Ok(_mapper.Map<UserResponse>(response));
        }

        /// <summary>
        /// Изменение сущности "Пользователь".
        /// </summary>
        /// <param name="request">Экземпляр <see cref="UpdateUserRequest"/>.</param>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <returns>Сущность "Пользователь".</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        [Authorize]
        public async Task<IActionResult> PutAsync(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Users/PutAsync was requested.");
            var response = await _userService.UpdateAsync(_mapper.Map<UserDto>(request));
            return Ok(_mapper.Map<UserResponse>(response));
        }

        /// <summary>
        /// Удаление сущностей "Пользователь".
        /// </summary>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <param name="ids">Идентификаторы сущностей.</param>
        /// <returns>Пустой ответ в виде статусного кода 204.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(CancellationToken cancellationToken, params long[] ids)
        {
            _logger.LogInformation("Users/DeleteAsync was requested.");
            await _userService.DeleteAsync(ids);
            return NoContent();
        }
    }
}

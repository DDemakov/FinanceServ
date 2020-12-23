using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinanceServ.Common.Swagger;
using AutoMapper;
using Microsoft.Extensions.Logging;
using FinanceServ.Services.Interfaces;
using FinanceServ.Models.DTO;
using FinanceServ.Models.Requests.Role;
using FinanceServ.Models.Responses.Role;

namespace FinanceServ.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными о ролях.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = SwaggerDocParts.Roles)]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="RoleController"/>.
        /// </summary>
        /// <param name="roleService">Сервис работы с ролями.</param>
        /// <param name="logger">Логгер.</param>
        /// <param name="mapper">Маппер.</param>
        public RoleController(IRoleService roleService, ILogger<RoleController> logger, IMapper mapper)
        {
            _roleService = roleService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка доступных ролей.
        /// </summary>
        /// <returns>Коллекция сущностей "Роли".</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RoleResponse>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Roles/GetAsync was requested.");
            var response = await _roleService.GetAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<RoleResponse>>(response));
        }

        /// <summary>
        /// Получение роли по Id.
        /// </summary>
        /// <returns>Сущность "Роль".</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoleResponse))]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Roles/GetByIdAsync was requested.");
            var response = await _roleService.GetAsync(id, cancellationToken);
            return Ok(_mapper.Map<RoleResponse>(response));
        }

        /// <summary>
        /// Добавление сущности "Роль".
        /// </summary>
        /// <param name="request">Экземпляр <see cref="CreateRoleRequest"/>.</param>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <returns>Сущность "Роль".</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoleResponse))]
        public async Task<IActionResult> PostAsync(CreateRoleRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Roles/PostAsync was requested.");
            var response = await _roleService.CreateAsync(_mapper.Map<RoleDto>(request));
            return Ok(_mapper.Map<RoleResponse>(response));
        }

        /// <summary>
        /// Изменение сущности "Роль".
        /// </summary>
        /// <param name="request">Экземпляр <see cref="UpdateStockRequest"/>.</param>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <returns>Сущность "Роль".</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoleResponse))]
        public async Task<IActionResult> PutAsync(UpdateRoleRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Roles/PutAsync was requested.");
            var response = await _roleService.UpdateAsync(_mapper.Map<RoleDto>(request));
            return Ok(_mapper.Map<RoleResponse>(response));
        }

        /// <summary>
        /// Удаление сущностей "Роль".
        /// </summary>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <param name="ids">Идентификаторы сущностей.</param>
        /// <returns>Пустой ответ в виде статусного кода 204.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(CancellationToken cancellationToken, params long[] ids)
        {
            _logger.LogInformation("Roles/DeleteAsync was requested.");
            await _roleService.DeleteAsync(ids);
            return NoContent();
        }
    }
}

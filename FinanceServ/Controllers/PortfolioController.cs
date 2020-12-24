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
using FinanceServ.Models.Requests.Portfolio;
using FinanceServ.Models.Responses.Portfolio;

namespace FinanceServ.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными о финансовых портфелях.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PortfolioController : ControllerBase
    {
        private readonly ILogger<PortfolioController> _logger;
        private readonly IPortfolioService _portfolioService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="PortfolioController"/>.
        /// </summary>
        /// <param name="portfolioService">Сервис работы с финансовыми портфелями.</param>
        /// <param name="logger">Логгер.</param>
        /// <param name="mapper">Маппер.</param>
        public PortfolioController(IPortfolioService portfolioService, ILogger<PortfolioController> logger, IMapper mapper)
        {
            _portfolioService = portfolioService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка доступных финансовых портфелей.
        /// </summary>
        /// <returns>Коллекция сущностей "Валюты".</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PortfolioResponse>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Portfolios/GetAsync was requested.");
            var response = await _portfolioService.GetAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<PortfolioResponse>>(response));
        }

        /// <summary>
        /// Получение финансового портфеля по Id.
        /// </summary>
        /// <returns>Сущность "Финансовый портфель".</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PortfolioResponse))]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Portfolios/GetByIdAsync was requested.");
            var response = await _portfolioService.GetAsync(id, cancellationToken);
            return Ok(_mapper.Map<PortfolioResponse>(response));
        }

        /// <summary>
        /// Добавление сущности "Финансовый портфель".
        /// </summary>
        /// <param name="request">Экземпляр <see cref="CreatePortfolioRequest"/>.</param>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <returns>Сущность "Финансовый портфель".</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PortfolioResponse))]
        public async Task<IActionResult> PostAsync(CreatePortfolioRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Portfolios/PostAsync was requested.");
            var response = await _portfolioService.CreateAsync(_mapper.Map<PortfolioDto>(request));
            return Ok(_mapper.Map<PortfolioResponse>(response));
        }

        /// <summary>
        /// Изменение сущности "Финансовый портфель".
        /// </summary>
        /// <param name="request">Экземпляр <see cref="UpdatePortfolioRequest"/>.</param>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <returns>Сущность "Финансовый портфель".</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PortfolioResponse))]
        public async Task<IActionResult> PutAsync(UpdatePortfolioRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Portfolios/PutAsync was requested.");
            var response = await _portfolioService.UpdateAsync(_mapper.Map<PortfolioDto>(request));
            return Ok(_mapper.Map<PortfolioResponse>(response));
        }

        /// <summary>
        /// Удаление сущностей "Финансовый портфель".
        /// </summary>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <param name="ids">Идентификаторы сущностей.</param>
        /// <returns>Пустой ответ в виде статусного кода 204.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(CancellationToken cancellationToken, params long[] ids)
        {
            _logger.LogInformation("Portfolios/DeleteAsync was requested.");
            await _portfolioService.DeleteAsync(ids);
            return NoContent();
        }
    }
}

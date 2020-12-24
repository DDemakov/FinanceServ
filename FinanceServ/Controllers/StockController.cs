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
using FinanceServ.Models.Requests.Stock;
using FinanceServ.Models.Responses.Stock;

namespace FinanceServ.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными об акциях.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StockController : ControllerBase
    {
        private readonly ILogger<StockController> _logger;
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="StockController"/>.
        /// </summary>
        /// <param name="stockService">Сервис работы с акциями.</param>
        /// <param name="logger">Логгер.</param>
        /// <param name="mapper">Маппер.</param>
        public StockController(IStockService stockService, ILogger<StockController> logger, IMapper mapper)
        {
            _stockService = stockService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка доступных акций.
        /// </summary>
        /// <returns>Коллекция сущностей "Акции".</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StockResponse>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stocks/GetAsync was requested.");
            var response = await _stockService.GetAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<StockResponse>>(response));
        }

        /// <summary>
        /// Получение акции по Id.
        /// </summary>
        /// <returns>Сущность "Акция".</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockResponse))]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stocks/GetByIdAsync was requested.");
            var response = await _stockService.GetAsync(id, cancellationToken);
            return Ok(_mapper.Map<StockResponse>(response));
        }

        /// <summary>
        /// Добавление сущности "Акция".
        /// </summary>
        /// <param name="request">Экземпляр <see cref="CreateStockRequest"/>.</param>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <returns>Сущность "Акция".</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockResponse))]
        public async Task<IActionResult> PostAsync(CreateStockRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stocks/PostAsync was requested.");
            var response = await _stockService.CreateAsync(_mapper.Map<StockDto>(request));
            return Ok(_mapper.Map<StockResponse>(response));
        }

        /// <summary>
        /// Изменение сущности "Акция".
        /// </summary>
        /// <param name="request">Экземпляр <see cref="UpdateStockRequest"/>.</param>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <returns>Сущность "Акция".</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockResponse))]
        public async Task<IActionResult> PutAsync(UpdateStockRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stocks/PutAsync was requested.");
            var response = await _stockService.UpdateAsync(_mapper.Map<StockDto>(request));
            return Ok(_mapper.Map<StockResponse>(response));
        }

        /// <summary>
        /// Удаление сущностей "Акция".
        /// </summary>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <param name="ids">Идентификаторы сущностей.</param>
        /// <returns>Пустой ответ в виде статусного кода 204.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(CancellationToken cancellationToken, params long[] ids)
        {
            _logger.LogInformation("Stocks/DeleteAsync was requested.");
            await _stockService.DeleteAsync(ids);
            return NoContent();
        }
    }
}

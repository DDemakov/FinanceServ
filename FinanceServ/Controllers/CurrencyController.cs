using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.Extensions.Logging;
using FinanceServ.Services.Interfaces;
using FinanceServ.Models.DTO;
using FinanceServ.Models.Requests.Currency;
using FinanceServ.Models.Responses.Currency;
using FinanceServ.Common.Swagger;

namespace FinanceServ.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными о валютах.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly ICurrencyService _currencyService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="CurrencyController"/>.
        /// </summary>
        /// <param name="currencyService">Сервис работы с валютами.</param>
        /// <param name="logger">Логгер.</param>
        /// <param name="mapper">Маппер.</param>
        public CurrencyController(ICurrencyService currencyService, ILogger<CurrencyController> logger, IMapper mapper)
        {
            _currencyService = currencyService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка доступных валют.
        /// </summary>
        /// <returns>Коллекция сущностей "Валюты".</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CurrencyResponse>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Currencies/GetAsync was requested.");
            var response = await _currencyService.GetAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<CurrencyResponse>>(response));
        }

        /// <summary>
        /// Получение валюты по Id.
        /// </summary>
        /// <returns>Сущность "Валюта".</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CurrencyResponse))]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Currencies/GetByIdAsync was requested.");
            var response = await _currencyService.GetAsync(id, cancellationToken);
            return Ok(_mapper.Map<CurrencyResponse>(response));
        }

        /// <summary>
        /// Добавление сущности "Валюта".
        /// </summary>
        /// <param name="request">Экземпляр <see cref="CreateCurrencyRequest"/>.</param>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <returns>Сущность "Валюта".</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CurrencyResponse))]
        public async Task<IActionResult> PostAsync(CreateCurrencyRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Currencies/PostAsync was requested.");
            var response = await _currencyService.CreateAsync(_mapper.Map<CurrencyDto>(request));
            return Ok(_mapper.Map<CurrencyResponse>(response));
        }

        /// <summary>
        /// Изменение сущности "Валюта".
        /// </summary>
        /// <param name="request">Экземпляр <see cref="UpdateCurrencyRequest"/>.</param>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <returns>Сущность "Валюта".</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CurrencyResponse))]
        public async Task<IActionResult> PutAsync(UpdateCurrencyRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Currencies/PutAsync was requested.");
            var response = await _currencyService.UpdateAsync(_mapper.Map<CurrencyDto>(request));
            return Ok(_mapper.Map<CurrencyResponse>(response));
        }

        /// <summary>
        /// Удаление сущностей "Валюта".
        /// </summary>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <param name="ids">Идентификаторы сущностей.</param>
        /// <returns>Пустой ответ в виде статусного кода 204.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(CancellationToken cancellationToken, params long[] ids)
        {
            _logger.LogInformation("Currencies/DeleteAsync was requested.");
            await _currencyService.DeleteAsync(ids);
            return NoContent();
        }
    }
}

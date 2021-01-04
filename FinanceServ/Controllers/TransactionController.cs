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
using FinanceServ.Models.Requests.Transaction;
using FinanceServ.Models.Responses.Transaction;

namespace FinanceServ.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными о транзакциях.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="TransactionController"/>.
        /// </summary>
        /// <param name="transactionService">Сервис работы с транзакциями.</param>
        /// <param name="logger">Логгер.</param>
        /// <param name="mapper">Маппер.</param>
        public TransactionController(ITransactionService transactionService, ILogger<TransactionController> logger, IMapper mapper)
        {
            _transactionService = transactionService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка доступных транзакций.
        /// </summary>
        /// <returns>Коллекция сущностей "Транзакции".</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TransactionResponse>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Transactions/GetAsync was requested.");
            var response = await _transactionService.GetAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<TransactionResponse>>(response));
        }

        /// <summary>
        /// Получение транзакции по Id.
        /// </summary>
        /// <returns>Сущность "Транзакция".</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TransactionResponse))]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Transactions/GetByIdAsync was requested.");
            var response = await _transactionService.GetAsync(id, cancellationToken);
            return Ok(_mapper.Map<TransactionResponse>(response));
        }

        /// <summary>
        /// Добавление сущности "Транзакция".
        /// </summary>
        /// <param name="request">Экземпляр <see cref="CreateTransactionRequest"/>.</param>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <returns>Сущность "Акция".</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TransactionResponse))]
        public async Task<IActionResult> PostAsync(CreateTransactionRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Transactions/PostAsync was requested.");
            var response = await _transactionService.CreateAsync(_mapper.Map<TransactionDto>(request));
            return Ok(_mapper.Map<TransactionResponse>(response));
        }

        /// <summary>
        /// Изменение сущности "Транзакция".
        /// </summary>
        /// <param name="request">Экземпляр <see cref="UpdateStockRequest"/>.</param>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <returns>Сущность "Транзакция".</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TransactionResponse))]
        public async Task<IActionResult> PutAsync(UpdateTransactionRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Transactions/PutAsync was requested.");
            var response = await _transactionService.UpdateAsync(_mapper.Map<TransactionDto>(request));
            return Ok(_mapper.Map<TransactionResponse>(response));
        }

        /// <summary>
        /// Удаление сущностей "Транзакция".
        /// </summary>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <param name="ids">Идентификаторы сущностей.</param>
        /// <returns>Пустой ответ в виде статусного кода 204.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(CancellationToken cancellationToken, params long[] ids)
        {
            _logger.LogInformation("Transactions/DeleteAsync was requested.");
            await _transactionService.DeleteAsync(ids);
            return NoContent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinanceServ.Common.Swagger;
using Microsoft.Extensions.Logging;
using FinanceServ.Services.Interfaces;
using FinanceServ.Models.DTO;

namespace FinanceServ.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными об акциях.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = SwaggerDocParts.Stocks)]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly ILogger<StockController> _logger;

        /// <summary>
        /// Инициализирует экземпляр <see cref="StockController"/>
        /// </summary>
        /// <param name="stockService"></param>
        /// <param name="logger"></param>
        public StockController(IStockService stockService, ILogger<StockController> logger) =>
            (_stockService, _logger) = (stockService, logger);

        /// <summary>
        /// Получение списка доступных акций.
        /// </summary>
        /// <returns>Коллекция сущностей "Акции".</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StockDto>))]
        public IActionResult Get()
        {
            _logger.LogInformation("Stocks/Get was requested.");
            var response = _stockService.GetStocks();
            return Ok(response);
        }

    }
}
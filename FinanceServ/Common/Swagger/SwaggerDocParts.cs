namespace FinanceServ.Common.Swagger
{
    /// <summary>
    /// Константы для указания частей API в Swagger.
    /// </summary>
    public sealed class SwaggerDocParts
    {
        /// <summary>
        /// Константа для swagger-документа "Валюты".
        /// </summary>
        public const string Currencies = nameof(Currencies);

        /// <summary>
        /// Константа для swagger-документа "Финансовые портфели".
        /// </summary>
        public const string Portfolios = nameof(Portfolios);

        /// <summary>
        /// Константа для swagger-документа "Акция".
        /// </summary>
        public const string Stocks = nameof(Stocks);

        /// <summary>
        /// Константа для swagger-документа "Транзакции".
        /// </summary>
        public const string Transactions = nameof(Transactions);

        /// <summary>
        /// Константа для swagger-документа "Пользователи".
        /// </summary>
        public const string Users = nameof(Users);
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace FinanceServ.Common.Swagger
{
    /// <summary>
    /// Расширения для конфигурации Swagger.
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Настройка документов Swagger.
        /// </summary>
        /// <param name="services">Коллекция сервисов для DI.</param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerDocument(c =>
            {
                c.Title = "Currencies";
                c.DocumentName = SwaggerDocParts.Currencies;
                c.ApiGroupNames = new[] { SwaggerDocParts.Currencies };
                c.GenerateXmlObjects = true;
            })
            .AddSwaggerDocument(c =>
            {
                c.Title = "Portfolios";
                c.DocumentName = SwaggerDocParts.Portfolios;
                c.ApiGroupNames = new[] { SwaggerDocParts.Portfolios };
                c.GenerateXmlObjects = true;
            })
            .AddSwaggerDocument(c =>
            {
                c.Title = "Stocks";
                c.DocumentName = SwaggerDocParts.Stocks;
                c.ApiGroupNames = new[] { SwaggerDocParts.Stocks };
                c.GenerateXmlObjects = true;
            })
            .AddSwaggerDocument(c =>
            {
                c.Title = "Transactions";
                c.DocumentName = SwaggerDocParts.Transactions;
                c.ApiGroupNames = new[] { SwaggerDocParts.Transactions };
                c.GenerateXmlObjects = true;
            })
            .AddSwaggerDocument(c =>
            {
                c.Title = "Users";
                c.DocumentName = SwaggerDocParts.Users;
                c.ApiGroupNames = new[] { SwaggerDocParts.Users };
                c.GenerateXmlObjects = true;
            });
        }
    }
}

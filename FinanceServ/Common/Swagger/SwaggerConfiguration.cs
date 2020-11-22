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
                c.Title = "Stocks";
                c.DocumentName = SwaggerDocParts.Stocks;
                c.ApiGroupNames = new[] { SwaggerDocParts.Stocks };
                c.GenerateXmlObjects = true;
            });
        }
    }
}

using System.Collections.Generic;
using FinanceServ.DAL.Entities;

namespace FinanceServ.DAL.Mocks
{
    /// <summary>
    /// Mock для коллекции сущностей "Акции".
    /// </summary>
    public static class StockMock
    {
        /// <summary>
        /// Получение коллекции сущностей "Акции".
        /// </summary>
        /// <returns>Коллекция сущностей "Акции".</returns>
        public static IEnumerable<Stock> GetStockCollection()
        {
            return new List<Stock>
            {
                new Stock {Id = 1, Name = "Garmin", Ticker = "GRMN", Foundation= 1989,
                    Sector = "Электронные технологии", Industry = "Телекоммуникационное оборудование",
                    Description = "Американская компания. Производит GPS-навигационную технику " +
                    "и спортивные часы.", Country = "USA"},
                new Stock {Id = 2, Name = "Wells Fargo & Company", Ticker= "WFC", Foundation= 1852,
                    Sector = "Финансы", Industry = "Основные банки",
                    Description = "Американский банковский холдинг. Предоставляет финансовые и " +
                    "страховые услуги в США, Канаде и Пуэрто-Рико.", Country = "USA"},
                new Stock {Id = 3, Name = "Nvidia", Ticker = "NVDA", Foundation = 1993,
                    Sector = "Электронные технологии", Industry = "Полупроводники",
                    Description = " американская технологическая компания, " +
                    "разработчик графических процессоров и систем-на-чипе (SoC)", Country = "USA"},
                new Stock {Id = 4, Name = "Estee Lauder Companies Inc.", Ticker="EL", Foundation=1946,
                    Sector = "Потребительские товары недлительного пользования",
                    Industry = "Бытовые и хозяйственные товары",
                    Description = "американская компания, специализирующаяся на производстве и " +
                    "продаже престижных средств по уходу за кожей, декоративной косметики и " +
                    "парфюмерии, средств по уходу за волосами.", Country = "USA"}
            };
        }
    }
}

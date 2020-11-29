using FinanceServ.DAL.Entities;
using FinanceServ.Models.DTO;
using FinanceServ.Repositories.Interfaces.CRUD;

namespace FinanceServ.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с сущностями "Валюта".
    /// </summary>
    public interface ICurrencyRepository : ICrudRepository<CurrencyDto, Currency>
    {

    }
}

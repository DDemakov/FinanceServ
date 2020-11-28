using FinanceServ.DAL.Entities;
using FinanceServ.Models.DTO;
using FinanceServ.Repositories.Interfaces.CRUD;

namespace FinanceServ.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с сущностями "Пользователь".
    /// </summary>
    public interface IUserRepository : ICrudRepository<UserDto, User>
    {
    }
}

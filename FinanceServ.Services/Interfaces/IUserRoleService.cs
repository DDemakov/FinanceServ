using FinanceServ.Models.DTO;
using FinanceServ.Services.Interfaces.CRUD;

namespace FinanceServ.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с данными по сущности Пользователь-Роль.
    /// </summary>
    public interface IUserRoleService : ICrudService<UserRoleDto>
    {
    }
}

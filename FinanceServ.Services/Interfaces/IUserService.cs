using System.Threading.Tasks;
using FinanceServ.Models.DTO;
using FinanceServ.Services.Interfaces.CRUD;

namespace FinanceServ.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с данными по пользователям.
    /// </summary>
    public interface IUserService : ICrudService<UserDto>
    {
        /// <summary>
        /// Проверка наличия пользователя в базе.
        /// </summary>
        /// <param name="email">Эл. почта пользователя.</param>
        /// <returns></returns>
        Task<bool> IsAnExistingUserAsync(string email);

        /// <summary>
        /// Проверка пользовательских данных.
        /// </summary>
        /// <param name="email">Эл. почта пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns></returns>
        Task<bool> IsValidUserCredentialsAsync(string email, string password);

        /// <summary>
        /// Получение роли пользователя, если таковая существует.
        /// </summary>
        /// <param name="email">Эл. почта пользователя.</param>
        /// <returns></returns>
        Task<string> GetUserRoleAsync(string email);
    }
}

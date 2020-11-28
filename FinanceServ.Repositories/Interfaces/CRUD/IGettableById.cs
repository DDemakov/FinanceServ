using System.Threading.Tasks;

namespace FinanceServ.Repositories.Interfaces.CRUD
{
    /// <summary>
    /// Интерфейс для получения сущности по идентификатору.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    /// <typeparam name="TEntity">Модель сущности для БД.</typeparam>
    public interface IGettableById<TDto, TEntity>
    {
        /// <summary>
        /// Получение сущности по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Экземпляр DTO.</returns>
        Task<TDto> GetAsync(long id);
    }
}

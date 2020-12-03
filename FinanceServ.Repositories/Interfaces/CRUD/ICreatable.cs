using System.Threading.Tasks;

namespace FinanceServ.Repositories.Interfaces.CRUD
{
    /// <summary>
    /// Интерфейс для создания сущности.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    /// <typeparam name="TEntity">Модель сущности для БД.</typeparam>
    public interface ICreatable<TDto, TEntity>
    {
        /// <summary>
        /// Создание сущности.
        /// </summary>
        /// <param name="dto">DTO.</param>
        /// <returns>Идентификатор созданной сущности.</returns>
        Task<TDto> CreateAsync(TDto dto);
    }
}

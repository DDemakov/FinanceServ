using System.Threading;
using System.Threading.Tasks;

namespace FinanceServ.Repositories.Interfaces.CRUD
{
    /// <summary>
    /// Интерфейс для изменения сущности.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    /// <typeparam name="TEntity">Модель сущности для БД.</typeparam>
    public interface IUpdatable<TDto, TEntity>
    {
        /// <summary>
        /// Изменение сущности.
        /// </summary>
        /// <param name="dto">DTO.</param>
        /// <param name="token">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <returns>Обновлённая сущность.</returns>
        Task<TDto> UpdateAsync(TDto dto, CancellationToken token = default);
    }
}

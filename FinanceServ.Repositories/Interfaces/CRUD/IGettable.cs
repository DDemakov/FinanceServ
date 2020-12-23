using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceServ.Repositories.Interfaces.CRUD
{
    /// <summary>
    /// Интерфейс для получения сущностей.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    /// <typeparam name="TEntity">Модель сущности для БД.</typeparam>
    public interface IGettable<TDto, TEntity>
    {
        /// <summary>
        /// Получение сущностей.
        /// </summary>
        /// <param name="isCollectionWithIncludes">Параметр загрузки коллекции со связанными сущностями.</param>
        /// <param name="token">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <returns>Коллекция DTO.</returns>
        Task<IEnumerable<TDto>> GetAsync(bool isCollectionWithIncludes = false, CancellationToken token = default);
    }
}

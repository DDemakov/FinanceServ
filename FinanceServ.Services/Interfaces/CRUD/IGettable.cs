using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceServ.Services.Interfaces.CRUD
{
    /// <summary>
    /// Интерфейс сервиса для получения сущностей.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    public interface IGettable<TDto>
    {
        /// <summary>
        /// Получение сущностей.
        /// </summary>
        /// <param name="token">Экземпляр <see cref="CancellationToken"/></param>
        /// <returns>Коллекция DTO (сущностей).</returns>
        Task<IEnumerable<TDto>> GetAsync(CancellationToken token = default);
    }
}

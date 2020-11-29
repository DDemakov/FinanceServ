using System.Threading;
using System.Threading.Tasks;

namespace FinanceServ.Services.Interfaces.CRUD
{
    /// <summary>
    /// Интерфейс сервиса для получения сущности по идентификатору.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    public interface IGettableById<TDto>
    {
        /// <summary>
        /// Интерфейс сервиса для получения сущности по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="token">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <returns>Экземпляр сущности.</returns>
        Task<TDto> GetAsync(long id, CancellationToken token = default);
    }
}

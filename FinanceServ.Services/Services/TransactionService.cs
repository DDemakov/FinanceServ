using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FinanceServ.Models.DTO;
using FinanceServ.Services.Interfaces;
using FinanceServ.Repositories.Interfaces;
using FinanceServ.Services.Interfaces.CRUD;

namespace FinanceServ.Services.Services
{
    /// <summary>
    /// Сервис для работы с данными по транзакциям.
    /// </summary>
    public class TransactionService : ITransactionService
    {
        ITransactionRepository _repository;

        /// <summary>
        /// Инициализирует экземпляр <see cref="TransactionService"/>
        /// </summary>
        /// <param name="repository">Репозиторий.</param>
        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<TransactionDto> CreateAsync(TransactionDto dto)
        {
            return await _repository.CreateAsync(dto);
        }

        /// <inheritdoc cref="IGettable{TDto}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<TransactionDto>> GetAsync(CancellationToken token = default)
        {
            return await _repository.GetAsync();
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<TransactionDto> GetAsync(long id, CancellationToken token = default)
        {
            return await _repository.GetAsync(id);
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<TransactionDto> UpdateAsync(TransactionDto dto)
        {
            return await _repository.UpdateAsync(dto);
        }

        /// <inheritdoc cref="IDeletable.DeleteAsync(long[])"/>
        public async Task DeleteAsync(long[] ids)
        {
            await _repository.DeleteAsync(ids);
        }
    }
}

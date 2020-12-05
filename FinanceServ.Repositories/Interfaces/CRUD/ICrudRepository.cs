using FinanceServ.DAL.Contexts;

namespace FinanceServ.Repositories.Interfaces.CRUD
{
    /// <summary>
    /// Интерфейс репозиторя с базовыми CRUD-операциями.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    /// <typeparam name="TEntity">Модель сущности для БД.</typeparam>
    public interface ICrudRepository<TDto, TEntity> :
        ICreatable<TDto, TEntity>,
        IGettable<TDto, TEntity>,
        IGettableById<TDto, TEntity>,
        IUpdatable<TDto, TEntity>,
        IDeletable
    {
        FinanceServContext Context { get; }
    }
}

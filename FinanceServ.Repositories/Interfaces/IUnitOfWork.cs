namespace FinanceServ.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс общего репозитория UnitOfWork.
    /// </summary>
    public interface IUnitOfWork
    {
        ICurrencyRepository CurrencyRepository { get; }

        IPortfolioRepository PortfolioRepository { get; }

        IRoleRepository RoleRepository { get; }

        IStockRepository StockRepository { get; }

        ITransactionRepository TransactionRepository { get; }

        IUserRepository UserRepository { get; }

        IUserRoleRepository UserRoleRepository { get; }
    }
}

namespace FinanceServ.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ICurrencyRepository CurrencyRepository { get; }

        IPortfolioRepository PortfolioRepository { get; }

        IStockRepository StockRepository { get; }

        ITransactionRepository TransactionRepository { get; }

        IUserRepository UserRepository { get; }
    }
}

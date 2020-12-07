using AutoMapper;
using FinanceServ.DAL.Contexts;
using FinanceServ.Repositories.Interfaces;

namespace FinanceServ.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		public ICurrencyRepository CurrencyRepository { get; }
		public IPortfolioRepository PortfolioRepository { get; }
		public IStockRepository StockRepository { get; }
		public ITransactionRepository TransactionRepository { get; }
		public IUserRepository UserRepository { get; }

		private FinanceServContext _context;

		public UnitOfWork(FinanceServContext context, IMapper mapper)
		{
			CurrencyRepository = new CurrencyRepository(context, mapper);
			PortfolioRepository = new PortfolioRepository(context, mapper);
			StockRepository = new StockRepository(context, mapper);
			TransactionRepository = new TransactionRepository(context, mapper);
			UserRepository = new UserRepository(context, mapper);
		}
	}
}

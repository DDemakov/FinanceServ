using AutoMapper;
using FinanceServ.DAL.Contexts;
using FinanceServ.Repositories.Interfaces;

namespace FinanceServ.Repositories
{
	/// <summary>
	/// Общий репозиторий UnitOfWork.
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
		public ICurrencyRepository CurrencyRepository { get; }
		public IPortfolioRepository PortfolioRepository { get; }
		public IRoleRepository RoleRepository { get; }
		public IStockRepository StockRepository { get; }
		public ITransactionRepository TransactionRepository { get; }
		public IUserRepository UserRepository { get; }
		public IUserRoleRepository UserRoleRepository { get; }

		private FinanceServContext _context;

		public UnitOfWork(FinanceServContext context, IMapper mapper)
		{
			CurrencyRepository = new CurrencyRepository(context, mapper);
			PortfolioRepository = new PortfolioRepository(context, mapper);
			RoleRepository = new RoleRepository(context, mapper);
			StockRepository = new StockRepository(context, mapper);
			TransactionRepository = new TransactionRepository(context, mapper);
			UserRepository = new UserRepository(context, mapper);
			UserRoleRepository = new UserRoleRepository(context, mapper);
		}
	}
}

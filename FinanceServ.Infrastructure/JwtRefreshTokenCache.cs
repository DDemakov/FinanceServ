using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using FinanceServ.Infrastructure.Interfaces;

namespace FinanceServ.Infrastructure
{
    /// <summary>
    /// Caching RefreshToken.
    /// </summary>
    public class JwtRefreshTokenCache : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IJwtAuthManager _jwtAuthManager;

        /// <summary>
        /// Инициализация экземпляра <see cref="JwtRefreshTokenCache"/>.
        /// </summary>
        /// <param name="jwtAuthManager"><see cref="IJwtAuthManager"/>.</param>
        public JwtRefreshTokenCache(IJwtAuthManager jwtAuthManager)
        {
            _jwtAuthManager = jwtAuthManager;
        }

        /// <summary>
        /// Удаление старого токена.
        /// </summary>
        /// <param name="stoppingToken"><see cref="CancellationToken"/>.</param>
        /// <returns>Task.</returns>
        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        /// <summary>
        /// Remove action.
        /// </summary>
        /// <param name="state">State.</param>
        public void DoWork(object state)
        {
            _jwtAuthManager.RemoveExpiredRefreshTokens(DateTime.Now);
        }

        /// <summary>
        /// Stop removing.
        /// </summary>
        /// <param name="stoppingToken"><see cref="CancellationToken"/>.</param>
        /// <returns>Task.</returns>
        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Dispose timer.
        /// </summary>
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}

using System;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FinanceServ.Infrastructure.Interfaces
{
    /// <summary>
    /// Интерфейс для менеджера авторизации <see cref="JwtAuthManager"/>.
    /// </summary>
    public interface IJwtAuthManager
    {
        /// <summary>
        /// RefreshToken dictionary.
        /// </summary>
        IImmutableDictionary<string, RefreshToken> UsersRefreshTokensReanOnlyDictionary { get; }

        /// <summary>
        /// Generate tokens.
        /// </summary>
        /// <param name="email">User Email.</param>
        /// <param name="claims">Claim's array.</param>
        /// <param name="now">Текущая дата/время.</param>
        /// <returns><see cref="JwtAuthResult"/>.</returns>
        JwtAuthResult GenerateTokens(string email, Claim[] claims, DateTime now);

        /// <summary>
        /// Запуск обновления.
        /// </summary>
        /// <param name="refreshToken">RefreshToken.</param>
        /// <param name="accessToken">AccessToken.</param>
        /// <param name="now">Текущая дата/время.</param>
        /// <returns><see cref="JwtAuthResult"/>.</returns>
        JwtAuthResult Refresh(string refreshToken, string accessToken, DateTime now);

        /// <summary>
        /// Удаление RefreshToken.
        /// </summary>
        /// <param name="now">Текущая дата/время.</param>
        void RemoveExpiredRefreshTokens(DateTime now);

        /// <summary>
        /// Refresh by userEmail.
        /// </summary>
        /// <param name="email">User Email.</param>
        void RemoveRefreshTokenByUserEmail(string email);

        /// <summary>
        /// Decode token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);
    }
}

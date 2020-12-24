using System;
using System.Text.Json.Serialization;

namespace FinanceServ.Infrastructure
{
    /// <summary>
    /// Модель RefreshToken.
    /// </summary>
    public class RefreshToken
    {
        /// <summary>
        /// Почта пользователя.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Значение RefreshToken.
        /// </summary>
        [JsonPropertyName("tokenString")]
        public string TokenString { get; set; }

        /// <summary>
        /// Время окончания.
        /// </summary>
        [JsonPropertyName("expireAt")]
        public DateTime ExpireAt { get; set; }
    }
}

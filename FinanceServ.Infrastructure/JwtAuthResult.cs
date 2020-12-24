using System;
using System.Text.Json.Serialization;

namespace FinanceServ.Infrastructure
{
    /// <summary>
    /// Tokens result.
    /// </summary>
    public class JwtAuthResult
    {
        /// <summary>
        /// AccessToken.
        /// </summary>
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        /// <summary>
        /// RefreshToken.
        /// </summary>
        [JsonPropertyName("refreshToken")]
        public RefreshToken RefreshToken { get; set; }
    }
}

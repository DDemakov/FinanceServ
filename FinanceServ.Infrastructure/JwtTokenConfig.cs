using System.Text.Json.Serialization;

namespace FinanceServ.Infrastructure
{
    /// <summary>
    /// AT config from appconfig.
    /// </summary>
    public class JwtTokenConfig
    {
        /// <summary>
        /// Secret.
        /// </summary>
        [JsonPropertyName("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// Issuer.
        /// </summary>
        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// Audience.
        /// </summary>
        [JsonPropertyName("audience")]
        public string Audience { get; set; }

        /// <summary>
        /// AccessToken time.
        /// </summary>
        [JsonPropertyName("accessTokenExpiration")]
        public int AccessTokenExpiration { get; set; }

        /// <summary>
        /// RefreshToken time.
        /// </summary>
        [JsonPropertyName("refreshTokenExpiration")]
        public int RefreshTokenExpiration { get; set; }
    }
}

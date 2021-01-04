using System;
using System.Text.Json.Serialization;

namespace FinanceServ.Controllers.Request_Response
{
    /// <summary>
    /// RefreshToken request.
    /// </summary>
    public class RefreshTokenRequest
    {
        /// <summary>
        /// Значение RefreshToken.
        /// </summary>
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}

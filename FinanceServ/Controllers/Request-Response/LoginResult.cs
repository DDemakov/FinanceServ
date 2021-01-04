using System.Text.Json.Serialization;

namespace FinanceServ.Controllers.Request_Response
{
    /// <summary>
    /// Login response.
    /// </summary>
    public class LoginResult
    {
        /// <summary>
        /// Email.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Role.
        /// </summary>
        [JsonPropertyName("role")]
        public string Role { get; set; }

        /// <summary>
        /// AccessToken.
        /// </summary>
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        /// <summary>
        /// RefreshToken.
        /// </summary>
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}

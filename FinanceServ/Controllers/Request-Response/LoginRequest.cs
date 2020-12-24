using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinanceServ.Controllers.Request_Response
{
    /// <summary>
    /// Login request.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace FinanceServ.Models.Requests.Role
{
    public class CreateRoleRequest
    {
        /// <summary>
        /// Название роли.
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}

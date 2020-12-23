using System.ComponentModel.DataAnnotations;

namespace FinanceServ.Models.Requests.Role
{
    public class UpdateRoleRequest : CreateRoleRequest
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        [Required]
        public long Id { get; set; }
    }
}

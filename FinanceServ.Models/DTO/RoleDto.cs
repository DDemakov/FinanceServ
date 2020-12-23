using FinanceServ.DAL.Entities;

namespace FinanceServ.Models.DTO
{
    /// <summary>
    /// Роль пользователя в системе; DTO для <see cref="Role"/>.
    /// </summary>
    public class RoleDto : BaseDto
    {
        /// <summary>
        /// Название роли.
        /// </summary>
        public string Name { get; set; }
    }
}

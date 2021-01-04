using FinanceServ.DAL.Entities;

namespace FinanceServ.Models.DTO
{
    /// <summary>
    /// Сущностная связь пользователь-роль; DTO для <see cref="UserRole"/>
    /// </summary>
    public class UserRoleDto : BaseDto
    {
        /// <summary>
        /// Пользователь.
        /// </summary>
        public UserDto User { get; set; }

        /// <summary>
        /// Роль.
        /// </summary>
        public RoleDto Role { get; set; }
    }
}

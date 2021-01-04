using AutoMapper;
using FinanceServ.DAL.Entities;
using FinanceServ.Models.DTO;

namespace FinanceServ.Repositories.Mappings
{
    /// <summary>
    /// Профиль маппинга (Пользователь-роль).
    /// </summary>
    public class UserRoleProfile : Profile
    {
        /// <summary>
        /// Инициализрует экземпляр <see cref="UserRoleProfile"/>.
        /// </summary>
        public UserRoleProfile()
        {
            CreateMap<UserRole, UserRoleDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using FinanceServ.DAL.Entities;
using FinanceServ.Models.DTO;

namespace FinanceServ.Repositories.Mappings
{
    /// <summary>
    /// Профиль маппинга (Роли).
    /// </summary>
    public class RoleProfile : Profile
    {
        /// <summary>
        /// Инициализрует экземпляр <see cref="RoleProfile"/>.
        /// </summary>
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}

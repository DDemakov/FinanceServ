using AutoMapper;
using FinanceServ.Models.DTO;
using FinanceServ.Models.Requests.Role;
using FinanceServ.Models.Responses.Role;

namespace FinanceServ.Controllers.Mappings
{
    /// <summary>
    /// Маппинг для запросов и ответов контроллера сущности "Финансовый портфель".
    /// </summary>
    public class RoleProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="PortfolioProfile"/>.
        /// </summary>
        public RoleProfile()
        {
            CreateMap<CreateRoleRequest, RoleDto>();
            CreateMap<UpdateRoleRequest, RoleDto>();
            CreateMap<RoleDto, RoleResponse>();
        }
    }
}

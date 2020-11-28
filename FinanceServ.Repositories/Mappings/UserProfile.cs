using AutoMapper;
using FinanceServ.DAL.Entities;
using FinanceServ.Models.DTO;

namespace FinanceServ.Repositories.Mappings
{
    /// <summary>
    /// Профиль маппинга (Пользователь).
    /// </summary>
    public class UserProfile : Profile
    {
        /// <summary>
        /// Инициализрует экземпляр <see cref="UserProfile"/>.
        /// </summary>
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}

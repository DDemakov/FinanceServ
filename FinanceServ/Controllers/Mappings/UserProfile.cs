using AutoMapper;
using FinanceServ.Models.DTO;
using FinanceServ.Models.Requests.User;
using FinanceServ.Models.Responses.User;

namespace FinanceServ.Controllers.Mappings
{
    /// <summary>
    /// Маппинг для запросов и ответов контроллера сущности "Пользователь".
    /// </summary>
    public class UserProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="UserProfile"/>.
        /// </summary>
        public UserProfile()
        {
            CreateMap<CreateUserRequest, UserDto>();
            CreateMap<UpdateUserRequest, UserDto>();
            CreateMap<UserDto, UserResponse>();
        }
    }
}

using AutoMapper;
using GameStore.Models;
using GameStore.ViewModels;

namespace GameStore.Services.MapperService
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserModel, UserViewModel>()
                .ForMember(dest => dest.UserId, t => t.MapFrom(m => m.Id)).ReverseMap();

            CreateMap<UserModel, UserLoginResponseViewModel>()
                .ForMember(dest => dest.UserId, t => t.MapFrom(m => m.Id)).ReverseMap();
        }
    }
}

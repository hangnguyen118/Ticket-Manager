using AutoMapper;
using TicketManager.API.EntityModels;
using TicketManager.API.EntityModels.Dto.ApplicationUser;
using TicketManager.API.EntityModels.Dto.Cinema;
using TicketManager.API.EntityModels.Dto.Image;

namespace TicketManager.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() {
            CreateMap<ApplicationUser, CreateApplicationUserDto>().ReverseMap();
            CreateMap<ApplicationUser, GetApplicationUserDto>().ReverseMap();
            CreateMap<ApplicationUser, UpdateApplicationUserDto>().ReverseMap();

            CreateMap<Cinema, CreateCinemaDto>().ReverseMap();
            CreateMap<Cinema, GetCinemaDto>().ReverseMap();
            CreateMap<Cinema, UpdateCinemaDto>().ReverseMap();

            CreateMap<Image, CreateImageDto>().ReverseMap();
            CreateMap<Image, GetImageDto>().ReverseMap();
            CreateMap<Image, UpdateImageDto>().ReverseMap();
        }
    }
}

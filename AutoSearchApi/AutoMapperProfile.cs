using AutoMapper;
using AutoSearchApi.ViewModels;

namespace AutoSearchApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Models.Vehicle, Dealer1Vehicle>()
                .ForMember(dest => dest.VehicleStatus, config => config.MapFrom(s => s.Status))
                .ForMember(dest => dest.Status, config => config.Ignore());


            CreateMap<Models.Vehicle, Dealer2Vehicle>()
                .ForMember(dest => dest.VehicleStatus, config => config.MapFrom(s => s.Status))
                .ForMember(dest => dest.Status, config => config.Ignore());
        }
    }
}

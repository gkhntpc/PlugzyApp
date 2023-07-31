using AutoMapper;
using Plugzy.Domain;
using Plugzy.Models.Request;
using Plugzy.Models.Response;

namespace Plugzy.Models.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TestEntity, TestResponse>()
               .ReverseMap();
            CreateMap<LoginResponse, LoginRequest>().ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber))
              .ForMember(dst => dst.Code, opt => opt.MapFrom(s => s.OtpCode));
        }
    }
}

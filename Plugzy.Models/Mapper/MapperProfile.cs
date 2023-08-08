using AutoMapper;
using Plugzy.Domain;
using Plugzy.Domain.Entities;
using Plugzy.Models.Extensions;
using Plugzy.Models.Request;
using Plugzy.Models.Response;

namespace Plugzy.Models.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AppUser, UserListResponse>().ReverseMap();
            CreateMap<AppUser, CreateUserRequest>().ReverseMap();
            CreateMap<AppUser, UserResponse>().ReverseMap();

            CreateMap<Brand, CreateBrandRequest>().ReverseMap();
            CreateMap<Brand, BrandResponse>().ReverseMap();

            CreateMap<Country, CreateCountryRequest>().ReverseMap();
            CreateMap<Country, CountryResponse>().ReverseMap();

            CreateMap<City, CreateCityRequest>().ReverseMap();
            CreateMap<City, CityResponse>().ReverseMap();
            CreateMap<City, CityListResponse>().ForMember(ds => ds.Country, src => src.MapFrom(x => x.Country.Name)).ReverseMap();

        }
    }
}

using AutoMapper;
using Plugzy.Domain;
using Plugzy.Models.Response;

namespace Plugzy.Service.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TestEntity, TestResponse>()
               .ReverseMap();
        }
    }
}

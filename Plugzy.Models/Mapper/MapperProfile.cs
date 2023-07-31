using AutoMapper;
using Plugzy.Domain;
using Plugzy.Models.Response;

namespace Plugzy.Models.Mapper
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

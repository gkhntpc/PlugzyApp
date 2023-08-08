using AutoMapper;

using Plugzy.Domain.Entities;
using Plugzy.Models.Base;
using Plugzy.Models.Response.AppUsers;

namespace Plugzy.Models.Mapper.AppUsers;

public class AppUsersMapper : Profile
{
    public AppUsersMapper()
    {
        CreateMap<AppUser, CreatedAppUserResponse>()
            .ForMember(x => x.Name, y => y.MapFrom(m => m.FullName))
            .ForMember(x => x.Phone, y => y.MapFrom(m => m.PhoneNumber));

        CreateMap<AppUser, GetAppUserByIdResponse>()
            .ForMember(x => x.Name, y => y.MapFrom(m => m.FullName))
            .ForMember(x => x.Phone, y => y.MapFrom(m => m.PhoneNumber));

        CreateMap<AppUser, UpdatedAppUserResponse>()
            .ForMember(x => x.Name, y => y.MapFrom(m => m.FullName))
            .ForMember(x => x.Phone, y => y.MapFrom(m => m.PhoneNumber));

        CreateMap<AppUser, DeletedAppUserResponse>();

        CreateMap<IPaginate<AppUser>, AppUserListModel>()
            .ForMember(x => x.UserList, y => y.MapFrom(m => m.Items));
    }
}

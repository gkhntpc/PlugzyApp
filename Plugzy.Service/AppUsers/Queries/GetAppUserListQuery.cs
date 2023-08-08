using AutoMapper;

using MediatR;

using Plugzy.Domain.Entities;
using Plugzy.Infrastructure.Interface.Repository;
using Plugzy.Models.Base;
using Plugzy.Models.Request.AppUsers;
using Plugzy.Models.Response.AppUsers;

namespace Plugzy.Service.AppUsers.Queries;

public class GetAppUserListQuery : CommandBase<CommandResult<AppUserListModel>>
{
    public GetAppUserListRequest Model { get; }

    public GetAppUserListQuery(GetAppUserListRequest model)
    {
        Model = model;
    }

    public class Handler : IRequestHandler<GetAppUserListQuery, CommandResult<AppUserListModel>>
    {
        private readonly IGenericRepositoryAsync<AppUser> _appUserRepository;
        private readonly IMapper _mapper;

        public Handler(IGenericRepositoryAsync<AppUser> appUserRepository, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
        }

        public async Task<CommandResult<AppUserListModel>> Handle(GetAppUserListQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AppUser> appUsers = await _appUserRepository
                .GetListAsync(x => x.Type == (Domain.Entities.Type)request.Model.type, index: request.Model.page, size: request.Model.pageSize);

            return CommandResult<AppUserListModel>
                .GetSucceed(_mapper.Map<AppUserListModel>(appUsers));
        }
    }
}

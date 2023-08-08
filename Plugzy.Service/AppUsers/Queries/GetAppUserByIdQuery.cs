using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Identity;

using Plugzy.Domain.Entities;
using Plugzy.Models.Base;
using Plugzy.Models.Response.AppUsers;

namespace Plugzy.Service.AppUsers.Queries;

public class GetAppUserByIdQuery : CommandBase<CommandResult<GetAppUserByIdResponse>>
{
    public string Id { get; }

    public GetAppUserByIdQuery(string id)
    {
        Id = id;
    }

    public class Handler : IRequestHandler<GetAppUserByIdQuery, CommandResult<GetAppUserByIdResponse>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public Handler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CommandResult<GetAppUserByIdResponse>> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await _userManager.FindByIdAsync(request.Id);
            
            if (appUser is null)
                return CommandResult<GetAppUserByIdResponse>.NotFound();
            
            return CommandResult<GetAppUserByIdResponse>
                .GetSucceed(_mapper.Map<GetAppUserByIdResponse>(appUser));
        }
    }
}

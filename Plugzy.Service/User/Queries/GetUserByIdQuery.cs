using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Plugzy.Domain.Entities;
using Plugzy.Models.Base;
using Plugzy.Models.Response;
using Plugzy.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Service.User.Queries
{
    public class GetUserByIdQuery:CommandBase<CommandResult<UserResponse>>
    {
        private Guid Id { get; }
        public GetUserByIdQuery(Guid id):base()
        {
            Id = id;
        }
        public class Handler :IRequestHandler<GetUserByIdQuery,CommandResult<UserResponse>>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IMapper _mapper;
            public Handler(UserManager<AppUser> userManager,IMapper mapper)
            {
                _userManager = userManager;
                _mapper = mapper;
            }
            public async Task<CommandResult<UserResponse>> Handle(GetUserByIdQuery request,CancellationToken cancellationToken)
            {
                var getUser =await _userManager.Users.Where(u=>u.Id==request.Id).FirstOrDefaultAsync();
                if (getUser is null)
                {
                    return CommandResult<UserResponse>.GetFailed(MessageConstans.UserNotFound);
                }
                var viewModel = _mapper.Map<UserResponse>(getUser);
                return CommandResult<UserResponse>.GetSucceed(viewModel);
            }
        }
    }
}

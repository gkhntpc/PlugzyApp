using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Plugzy.Domain.Entities;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Service.User.Queries
{
    public class GetAllUserQuery:CommandBase<CommandResult<PagedResult<UserListResponse>>>
    {
        private PaginationRequest Model { get; }
        public GetAllUserQuery(PaginationRequest model) : base()
        {
            Model = model;
        }
        public class Handler : IRequestHandler<GetAllUserQuery, CommandResult<PagedResult<UserListResponse>>>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IMapper _mapper;
            public Handler(UserManager<AppUser> userManager,IMapper mapper)
            {
                _userManager = userManager;
                _mapper = mapper;
            }
            public async Task<CommandResult<PagedResult<UserListResponse>>> Handle(GetAllUserQuery request,CancellationToken cancellationToken)
            {
                var userList = await _userManager.Users.ToListAsync();
                var viewModel = _mapper.Map<List<UserListResponse>>(userList);
                var userResponsesList = await PagedResult<UserListResponse>.CreateAsync(viewModel, request.Model.Page, request.Model.PageSize);

                return CommandResult<PagedResult<UserListResponse>>.GetSucceed(userResponsesList);
            }
        }
    }
}

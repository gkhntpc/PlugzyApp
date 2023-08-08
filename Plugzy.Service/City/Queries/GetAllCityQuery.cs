using AutoMapper;
using MediatR;
using Plugzy.Infrastructure.Interface.Repository;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Service.City.Queries
{
    public class GetAllCityQuery : CommandBase<CommandResult<PagedResult<CityListResponse>>>
    {
        private PaginationRequest Model { get; }
        public GetAllCityQuery(PaginationRequest model) : base()
        {
            Model = model;
        }
        public class Handler : IRequestHandler<GetAllCityQuery, CommandResult<PagedResult<CityListResponse>>>
        {
            private readonly IGenericRepositoryAsync<Domain.Entities.City> _cityRepository;
            private readonly IMapper _mapper;
            public Handler(IGenericRepositoryAsync<Domain.Entities.City> cityRepository, IMapper mapper)
            {
                _cityRepository = cityRepository;
                _mapper = mapper;
            }
            public async Task<CommandResult<PagedResult<CityListResponse>>> Handle(GetAllCityQuery request, CancellationToken cancellationToken)
            {
                var cityList = await _cityRepository.GetAllAsync();
                var viewModel = _mapper.Map<List<CityListResponse>>(cityList);
                var cityResponsesList = await PagedResult<CityListResponse>.CreateAsync(viewModel, request.Model.Page, request.Model.PageSize);
                return CommandResult<PagedResult<CityListResponse>>.GetSucceed(cityResponsesList);
            }
        }
    }
}

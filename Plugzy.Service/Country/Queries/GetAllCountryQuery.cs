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

namespace Plugzy.Service.Country.Queries
{
    public class GetAllCountryQuery:CommandBase<CommandResult<PagedResult<CountryResponse>>>
    {
        private PaginationRequest Model { get; }
        public GetAllCountryQuery(PaginationRequest model):base()
        {
            Model = model;
        }
        public class Handler : IRequestHandler<GetAllCountryQuery, CommandResult<PagedResult<CountryResponse>>>
        {
            private readonly IGenericRepositoryAsync<Domain.Entities.Country> _countryRepository;
            private readonly IMapper _mapper;
            public Handler(IGenericRepositoryAsync<Domain.Entities.Country> countryRepository, IMapper mapper)
            {
                _countryRepository = countryRepository;
                _mapper = mapper;
            }
            public async Task<CommandResult<PagedResult<CountryResponse>>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
            {
                var countryList = await _countryRepository.GetAllAsync();
                var viewModel = _mapper.Map<List<CountryResponse>>(countryList);
                var countryResponsesList = await PagedResult<CountryResponse>.CreateAsync(viewModel, request.Model.Page, request.Model.PageSize);
                return CommandResult<PagedResult<CountryResponse>>.GetSucceed(countryResponsesList);
            }
        }
    }
}

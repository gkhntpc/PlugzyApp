using AutoMapper;
using MediatR;
using Plugzy.Infrastructure.Interface.Repository;
using Plugzy.Models.Base;
using Plugzy.Models.Response;
using Plugzy.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Service.Country.Queries
{
    public class GetCountryByIdQuery:CommandBase<CommandResult<CountryResponse>>
    {
        private Guid Id { get; }
        public GetCountryByIdQuery(Guid id):base()
        {
            Id = id;
        }
        public class Handler : IRequestHandler<GetCountryByIdQuery, CommandResult<CountryResponse>>
        {
            private readonly IGenericRepositoryAsync<Domain.Entities.Country> _countryRepository;
            private readonly IMapper _mapper;
            public Handler(IGenericRepositoryAsync<Domain.Entities.Country> countryRepository, IMapper mapper)
            {
                _countryRepository = countryRepository;
                _mapper = mapper;
            }
            public async Task<CommandResult<CountryResponse>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
            {
                var getCountry = await _countryRepository.GetAsync(c => c.Id == request.Id);
                if (getCountry is null)
                {
                    return CommandResult<CountryResponse>.GetFailed(MessageConstans.CountryNotFound);
                }

                var viewModel = _mapper.Map<CountryResponse>(getCountry);
                return CommandResult<CountryResponse>.GetSucceed(viewModel);
            }
        }
    }
}

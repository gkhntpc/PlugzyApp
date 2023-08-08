using AutoMapper;
using MediatR;
using Plugzy.Domain.Entities;
using Plugzy.Infrastructure.Interface.Repository;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;
using Plugzy.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Service.Country.Commands
{
    public class CreateCountryCommand : CommandBase<CommandResult<CountryResponse>>
    {
        private CreateCountryRequest Model { get; }
        public CreateCountryCommand(CreateCountryRequest model)
        {
            Model = model;
        }
        public class Handler : IRequestHandler<CreateCountryCommand, CommandResult<CountryResponse>>
        {
            private readonly IGenericRepositoryAsync<Domain.Entities.Country> _countryRepository;
            private readonly IMapper _mapper;
            public Handler(IGenericRepositoryAsync<Domain.Entities.Country> countryRepository, IMapper mapper)
            {
                _countryRepository = countryRepository;
                _mapper = mapper;
            }
            public async Task<CommandResult<CountryResponse>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
            {
                var checkCountry =await _countryRepository.GetAsync(c => c.Name == request.Model.Name);
                if (checkCountry is not null)
                {
                    return CommandResult<CountryResponse>.GetFailed(MessageConstans.CountryAlreadyExists);
                }
                var newCountry = _mapper.Map<Domain.Entities.Country>(request.Model);
                newCountry.Name = request.Model.Name;
                newCountry.IsActive= true;
                newCountry.CreatedAt = DateTime.UtcNow.Ticks;

                var result = await _countryRepository.CreateAsync(newCountry);
                if(result is not null) 
                {
                    var viewModel = _mapper.Map<CountryResponse>(newCountry);
                    return CommandResult<CountryResponse>.GetSucceed("", viewModel);
                }
                return CommandResult<CountryResponse>.GetFailed(MessageConstans.BadRequest);
            }
        }
    }
}

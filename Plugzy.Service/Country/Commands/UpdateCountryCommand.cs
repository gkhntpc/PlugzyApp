using AutoMapper;
using MediatR;
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
    public class UpdateCountryCommand: CommandBase<CommandResult<CountryResponse>>
    {
        private UpdateCountryRequest Model { get; }
        private Guid Id { get; }
        public UpdateCountryCommand(UpdateCountryRequest model,Guid id):base()
        {
            Model = model;
            Id = id;
        }
        public class Handler : IRequestHandler<UpdateCountryCommand, CommandResult<CountryResponse>>
        {
            private readonly IGenericRepositoryAsync<Domain.Entities.Country> _countryRepository;
            private readonly IMapper _mapper;
            public Handler(IGenericRepositoryAsync<Domain.Entities.Country> countryRepository, IMapper mapper)
            {
                _countryRepository = countryRepository;
                _mapper = mapper;
            }

            public async Task<CommandResult<CountryResponse>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
            {
                var getCountry = await _countryRepository.GetAsync(c=>c.Id == request.Id);
                if (getCountry is null) 
                {
                    return CommandResult<CountryResponse>.GetFailed(MessageConstans.CountryNotFound);
                }
                getCountry.Name=request.Model.Name;
                getCountry.IsActive=request.Model.IsActive;
                getCountry.UpdatedAt = DateTime.UtcNow.Ticks;

                var result = _countryRepository.UpdateAsync(getCountry);
                if(result is not null)
                {
                    var viewModel = _mapper.Map<CountryResponse>(getCountry);
                    return CommandResult<CountryResponse>.GetSucceed(viewModel);
                }
                return CommandResult<CountryResponse>.GetFailed(MessageConstans.BadRequest);
            }
        }
    }
}

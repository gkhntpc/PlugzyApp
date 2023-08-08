using MediatR;
using Plugzy.Domain.Entities;
using Plugzy.Infrastructure.Interface.Repository;
using Plugzy.Models.Base;
using Plugzy.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Service.Country.Commands
{
    public class DeleteCountryCommand:CommandBase<CommandResult<Domain.Entities.Country>>
    {
        private Guid Id { get; }
        public DeleteCountryCommand(Guid id):base()
        {
            Id = id;
        }
        public class Handler : IRequestHandler<DeleteCountryCommand, CommandResult<Domain.Entities.Country>>
        {
            private readonly IGenericRepositoryAsync<Domain.Entities.Country> _countryRepository;
            public Handler(IGenericRepositoryAsync<Domain.Entities.Country> countryReposity)
            {
                _countryRepository = countryReposity;
            }
            public async Task<CommandResult<Domain.Entities.Country>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
            {
                var getCountry = await _countryRepository.GetAsync(c => c.Id == request.Id);
                if(getCountry is null)
                {
                    return CommandResult<Domain.Entities.Country>.GetFailed(MessageConstans.CountryNotFound);
                }
                var result =_countryRepository.RemoveAsync(getCountry);
                if(result is not null)
                {
                    return CommandResult<Domain.Entities.Country>.GetSucceed("", null);
                }
                return CommandResult<Domain.Entities.Country>.GetFailed(MessageConstans.BadRequest);

            }
        }
    }
}

using MediatR;
using Plugzy.Infrastructure.Interface.Repository;
using Plugzy.Models.Base;
using Plugzy.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Service.City.Commands
{
    public class DeleteCityCommand:CommandBase<CommandResult<Domain.Entities.City>>
    {
        private Guid Id { get; }
        public DeleteCityCommand(Guid id):base()
        {
            Id = id;
        }
        public class Handler : IRequestHandler<DeleteCityCommand, CommandResult<Domain.Entities.City>>
        {
            private readonly IGenericRepositoryAsync<Domain.Entities.City> _cityRepository;
            public Handler(IGenericRepositoryAsync<Domain.Entities.City> cityRepository)
            {
                _cityRepository = cityRepository;
            }
            public async Task<CommandResult<Domain.Entities.City>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
            {
                var getCity = await _cityRepository.GetAsync(c=>c.Id==request.Id);
                if (getCity is null) 
                {
                    return CommandResult<Domain.Entities.City>.GetFailed(MessageConstans.CityNotFound);
                }

                var result = _cityRepository.RemoveAsync(getCity);
                if(result is not null)
                {
                    return CommandResult<Domain.Entities.City>.GetSucceed("", null);
                }
                return CommandResult<Domain.Entities.City>.GetFailed(MessageConstans.BadRequest);
            }
        }
    }
}

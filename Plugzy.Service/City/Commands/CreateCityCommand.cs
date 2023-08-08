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

namespace Plugzy.Service.City.Commands
{
    public class CreateCityCommand : CommandBase<CommandResult<CityResponse>>
    {
        private CreateCityRequest Model { get; }
        public CreateCityCommand(CreateCityRequest model)
        {
            Model = model;
        }
        public class Handler : IRequestHandler<CreateCityCommand, CommandResult<CityResponse>>
        {
            private readonly IGenericRepositoryAsync<Domain.Entities.City> _cityRepository;
            private readonly IMapper _mapper;
            public Handler(IGenericRepositoryAsync<Domain.Entities.City> cityRepository, IMapper mapper)
            {
                _cityRepository = cityRepository;
                _mapper = mapper;
            }
            public async Task<CommandResult<CityResponse>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
            {
                var checkCity = await _cityRepository.GetAsync(c => c.Name == request.Model.Name);
                if (checkCity is not null)
                {
                    return CommandResult<CityResponse>.GetFailed(MessageConstans.CityAlreadyExists);
                }
                var newCity = _mapper.Map<Domain.Entities.City>(request.Model);
                newCity.CreatedAt = DateTime.UtcNow.Ticks;
                newCity.IsActive = true;

                var result = await _cityRepository.CreateAsync(newCity);
                if (result is not null)
                {
                    var viewModel = _mapper.Map<CityResponse>(newCity);
                    return CommandResult<CityResponse>.GetSucceed("", viewModel);
                }
                return CommandResult<CityResponse>.GetFailed(MessageConstans.BadRequest);
            }
        }
    }
}

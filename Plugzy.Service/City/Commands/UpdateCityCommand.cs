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

namespace Plugzy.Service.City.Commands
{
    public class UpdateCityCommand:CommandBase<CommandResult<CityResponse>>
    {
        private UpdateCityRequest Model { get; }
        private Guid Id { get; }
        public UpdateCityCommand(UpdateCityRequest model,Guid id):base()
        {
            Model = model;
            Id = id;
        }
        public class Handler : IRequestHandler<UpdateCityCommand,CommandResult<CityResponse>>
        {
            private readonly IGenericRepositoryAsync<Domain.Entities.City> _cityRepository;
            private readonly IMapper _mapper;
            public Handler(IGenericRepositoryAsync<Domain.Entities.City> cityRepository,IMapper mapper)
            {
                _cityRepository = cityRepository;
                _mapper = mapper;
            }
            public async Task<CommandResult<CityResponse>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
            {
                var getCity = await _cityRepository.GetAsync(c => c.Id == request.Id);
                if(getCity is null)
                {
                    return CommandResult<CityResponse>.GetFailed(MessageConstans.CityNotFound);
                }
                getCity.Name= request.Model.Name;
                getCity.IsActive = request.Model.IsActive;
                getCity.CountryId = request.Model.CountryId;
                getCity.UpdatedAt = DateTime.UtcNow.Ticks;

                var result = _cityRepository.UpdateAsync(getCity);
                if(result is not null)
                {
                    var viewModel = _mapper.Map<CityResponse>(result);
                    return CommandResult<CityResponse>.GetSucceed(viewModel);
                }
                return CommandResult<CityResponse>.GetFailed(MessageConstans.BadRequest);
            }
        }
    }
}

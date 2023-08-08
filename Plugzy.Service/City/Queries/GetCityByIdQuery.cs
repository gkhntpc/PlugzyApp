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

namespace Plugzy.Service.City.Queries
{
    public class GetCityByIdQuery:CommandBase<CommandResult<CityResponse>>
    {
        private Guid Id { get; }
        public GetCityByIdQuery(Guid id):base()
        {
            Id = id;
        }
        public class Handler : IRequestHandler<GetCityByIdQuery, CommandResult<CityResponse>>
        {
            private readonly IGenericRepositoryAsync<Domain.Entities.City> _cityRepository;
            private readonly IMapper _mapper;
            public Handler(IGenericRepositoryAsync<Domain.Entities.City> cityRepository, IMapper mapper)
            {
                _cityRepository = cityRepository;
                _mapper = mapper;
            }

            public async Task<CommandResult<CityResponse>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
            {
                var getCity = await _cityRepository.GetAsync(c => c.Id == request.Id);
                if (getCity is null)
                {
                    return CommandResult<CityResponse>.GetFailed(MessageConstans.CityNotFound);
                }

                var viewModel = _mapper.Map<CityResponse>(getCity);
                return CommandResult<CityResponse>.GetSucceed(viewModel);
            }






        }
    }
}

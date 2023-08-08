using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plugzy.Domain.Entities;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;
using Plugzy.Service.Brand.Commands;
using Plugzy.Service.Brand.Queries;
using Plugzy.Service.City.Commands;
using Plugzy.Service.City.Queries;

namespace Plugzy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<CityResponse>))]
        public async Task<CommandResult<CityResponse>> CreateCity([FromBody] CreateCityRequest request)
        {
            var response = await _mediator.Send(new CreateCityCommand(request));
            return response;
        }
        [HttpDelete]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<City>))]
        public async Task<CommandResult<City>> DeleteCity(Guid Id)
        {
            var response = await _mediator.Send(new DeleteCityCommand(Id));
            return response;
        }
        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<CityResponse>))]
        public async Task<CommandResult<CityResponse>> UpdateCity(Guid Id, [FromBody] UpdateCityRequest request)
        {
            var response = await _mediator.Send(new UpdateCityCommand(request, Id));
            return response;
        }
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<CityResponse>))]
        public async Task<CommandResult<CityResponse>> GetUserById(Guid Id)
        {
            var response = await _mediator.Send(new GetCityByIdQuery(Id));
            return response;
        }
        [HttpGet]
        [Route("CityList")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<PagedResult<CityListResponse>>))]
        public async Task<CommandResult<PagedResult<CityListResponse>>> GetAllUserList([FromQuery] PaginationRequest request)
        {
            var response = await _mediator.Send(new GetAllCityQuery(request));
            return response;
        }
    }
}

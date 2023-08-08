using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plugzy.Domain.Entities;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;
using Plugzy.Service.Brand.Commands;
using Plugzy.Service.Country.Commands;
using Plugzy.Service.Country.Queries;

namespace Plugzy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<CountryResponse>))]
        public async Task<CommandResult<CountryResponse>> CreateCountry([FromBody] CreateCountryRequest request)
        {
            var response = await _mediator.Send(new CreateCountryCommand(request));
            return response;
        }
        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<CountryResponse>))]
        public async Task<CommandResult<CountryResponse>> UpdateCountry(Guid Id,[FromBody] UpdateCountryRequest request)
        {
            var response = await _mediator.Send(new UpdateCountryCommand(request, Id));
            return response;
        }
        [HttpDelete]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<Country>))]
        public async Task<CommandResult<Country>> DeleteCountry(Guid Id)
        {
            var response = await _mediator.Send(new DeleteCountryCommand(Id));
            return response;
        }
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<CountryResponse>))]
        public async Task<CommandResult<CountryResponse>> GetCountryById(Guid Id)
        {
            var response = await _mediator.Send(new GetCountryByIdQuery(Id));
            return response;
        }
        [HttpGet]
        [Route("CountryList")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<PagedResult<CountryResponse>>))]
        public async Task<CommandResult<PagedResult<CountryResponse>>> GetAllCountryList([FromQuery]PaginationRequest request)
        {
            var response = await _mediator.Send(new GetAllCountryQuery(request));
            return response;
        }


    }
}

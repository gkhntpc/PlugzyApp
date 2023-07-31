using MediatR;
using Microsoft.AspNetCore.Mvc;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;
using Plugzy.Service.TestServices.Command;

namespace Plugzy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("TestSend")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<TestResponse>))]
        public async Task<CommandResult<TestResponse>> TestSend([FromBody] TestRequest request) 
        {
            var tt = await _mediator.Send(new TestCommand(request));
            return tt;
        }

    }
}

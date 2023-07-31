using AutoMapper;
using MediatR;
using Plugzy.Domain;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;

namespace Plugzy.Service.TestServices.Command
{
    public class TestCommand : CommandBase<CommandResult<TestResponse>>
    {
        private TestRequest Model { get; }

        public TestCommand(TestRequest model) : base()
        {
            Model = model;

        }
        public class Handler : IRequestHandler<TestCommand, CommandResult<TestResponse>>
        {
            public async Task<CommandResult<TestResponse>> Handle(TestCommand request, CancellationToken cancellationToken)
            {
                var returnModel = new TestEntity() { TestData = true };

                //OK
                if (returnModel.TestData)
                {
                    return CommandResult<TestResponse>.GetSucceed(_mapper.Map<TestResponse>(returnModel));
                }

                //FAIL
                return CommandResult<TestResponse>.GetFailed("");
            }

            private readonly IMapper _mapper;
            public Handler(IMapper mapper)
            {
                _mapper = mapper;
            }
        }
    }
}

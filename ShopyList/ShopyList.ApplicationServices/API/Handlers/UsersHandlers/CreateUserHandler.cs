using AutoMapper;
using ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse;
using ShopyList.DataAccess.CQRS.Commands.ProductsCommands;
using ShopyList.DataAccess.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ShopyList.ApplicationServices.API.Domain.UserRequestResponse;
using ShopyList.DataAccess.CQRS.Commands.UsersCommands;

namespace ShopyList.ApplicationServices.API.Handlers.UsersHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public CreateUserHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<DataAccess.Entities.User>(request);
            var command = new CreateUserCommand() { Parameter = user };
            var userFromDb = await this.commandExecutor.Execute(command);
            return new CreateUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(userFromDb)
            };
        }
    }
}

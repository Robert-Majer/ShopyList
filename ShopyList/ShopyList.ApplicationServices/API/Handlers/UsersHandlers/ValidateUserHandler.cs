using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain.UserRequestResponse;
using ShopyList.DataAccess.CQRS.Commands.UsersCommands;
using ShopyList.DataAccess.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse;
using ShopyList.ApplicationServices.API.ErrorHandling;
using ShopyList.DataAccess.CQRS.Commands.ProductsCommands;

namespace ShopyList.ApplicationServices.API.Handlers.UsersHandlers
{
    public class ValidateUserHandler : IRequestHandler<ValidateUserRequest, ValidateUserResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public ValidateUserHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<ValidateUserResponse> Handle(ValidateUserRequest request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<DataAccess.Entities.User>(request);
            var command = new ValidateUserCommand() { Parameter = user };
            var userFromDb = await this.commandExecutor.Execute(command);

            if (userFromDb == null)
            {
                return new ValidateUserResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            return new ValidateUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(userFromDb)
            };
        }
    }
}

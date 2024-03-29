﻿using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse;
using ShopyList.ApplicationServices.API.ErrorHandling;
using ShopyList.DataAccess.CQRS;
using ShopyList.DataAccess.CQRS.Commands.ShopsCommands;

namespace ShopyList.ApplicationServices.API.Handlers.ShopsHandlers
{
    public class EditShopHandler : IRequestHandler<EditShopRequest, EditShopResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public EditShopHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<EditShopResponse> Handle(EditShopRequest request, CancellationToken cancellationToken)
        {
            var shop = this.mapper.Map<DataAccess.Entities.Shop>(request);
            var command = new EditShopCommand() { Parameter = shop };
            var shopFromDb = await this.commandExecutor.Execute(command);

            if (shopFromDb == null)
            {
                return new EditShopResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            return new EditShopResponse()
            {
                Data = this.mapper.Map<Domain.Models.Shop>(shopFromDb)
            };
        }
    }
}
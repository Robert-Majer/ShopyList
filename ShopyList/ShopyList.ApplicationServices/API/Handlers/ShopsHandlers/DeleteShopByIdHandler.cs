using AutoMapper;
using ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse;
using ShopyList.DataAccess.CQRS.Commands;
using ShopyList.DataAccess.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ShopyList.DataAccess.CQRS.Queries;
using ShopyList.DataAccess.CQRS.Commands.ShopsCommands;

namespace ShopyList.ApplicationServices.API.Handlers.ShopsHandlers
{
    public class DeleteShopByIdHandler : IRequestHandler<DeleteShopByIdRequest, DeleteShopByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public DeleteShopByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteShopByIdResponse> Handle(DeleteShopByIdRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteShopByIdCommand()
            {
                Id = request.ShopId
            };
            var shopFromDb = await this.commandExecutor.Execute(command);
            return new DeleteShopByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Shop>(shopFromDb)
            };
        }
    }
}
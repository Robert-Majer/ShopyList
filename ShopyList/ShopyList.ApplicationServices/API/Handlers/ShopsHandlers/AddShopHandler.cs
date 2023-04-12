using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse;
using ShopyList.DataAccess.CQRS;
using ShopyList.DataAccess.CQRS.Commands.ShopsCommands;

namespace ShopyList.ApplicationServices.API.Handlers
{
    public class AddShopHandler : IRequestHandler<AddShopRequest, AddShopResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddShopHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddShopResponse> Handle(AddShopRequest request, CancellationToken cancellationToken)
        {
            var shop = this.mapper.Map<DataAccess.Entities.Shop>(request);
            var command = new AddShopCommand() { Parameter = shop };
            var shopFromDb = await this.commandExecutor.Execute(command);
            return new AddShopResponse()
            {
                Data = this.mapper.Map<Domain.Models.Shop>(shopFromDb)
            };
        }
    }
}
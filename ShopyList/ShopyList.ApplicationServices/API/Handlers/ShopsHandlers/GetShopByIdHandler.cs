using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse;
using ShopyList.ApplicationServices.API.ErrorHandling;
using ShopyList.DataAccess.CQRS;
using ShopyList.DataAccess.CQRS.Queries.ShopsQueries;

namespace ShopyList.ApplicationServices.API.Handlers.ShopsHandlers
{
    public class GetShopByIdHandler : IRequestHandler<GetShopByIdRequest, GetShopByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetShopByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetShopByIdResponse> Handle(GetShopByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetShopQuery()
            {
                Id = request.ShopId
            };

            var shop = await this.queryExecutor.Excecute(query);
            if (shop == null)
            {
                return new GetShopByIdResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedShop = this.mapper.Map<Domain.Models.Shop>(shop);
            var response = new GetShopByIdResponse()
            {
                Data = mappedShop
            };
            return response;
        }
    }
}
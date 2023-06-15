using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse;
using ShopyList.DataAccess.CQRS;
using ShopyList.DataAccess.CQRS.Queries.ProductsQueries;

namespace ShopyList.ApplicationServices.API.Handlers.ProductsHandlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetProductsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductsQuery();
            var products = await queryExecutor.Execute(query);
            var mappedProduct = mapper.Map<List<Domain.Models.Product>>(products);
            var response = new GetProductsResponse()
            {
                Data = mappedProduct
            };
            return response;
        }
    }
}
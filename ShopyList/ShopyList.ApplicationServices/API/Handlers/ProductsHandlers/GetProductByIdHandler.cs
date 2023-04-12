using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse;
using ShopyList.DataAccess.CQRS;
using ShopyList.DataAccess.CQRS.Queries.ProductsQueries;

namespace ShopyList.ApplicationServices.API.Handlers.ProductsHandlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetProductByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductQuery()
            {
                Id = request.ProductId
            };

            var product = await this.queryExecutor.Excecute(query);
            var mappedProduct = this.mapper.Map<Domain.Models.Product>(product);
            var response = new GetProductByIdResponse()
            {
                Data = mappedProduct
            };
            return response;
        }
    }
}
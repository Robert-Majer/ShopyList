using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain;
using ShopyList.DataAccess.CQRS;
using ShopyList.DataAccess.CQRS.Queries;

namespace ShopyList.ApplicationServices.API.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProtuctsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetProductsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetProtuctsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductsQuery()
            {
                Name = request.Name
            };

            var products = await this.queryExecutor.Excecute(query);
            var mappedProduct = this.mapper.Map<List<Domain.Models.Product>>(products);
            var response = new GetProtuctsResponse()
            {
                Data = mappedProduct
            };
            return response;
        }
    }
}
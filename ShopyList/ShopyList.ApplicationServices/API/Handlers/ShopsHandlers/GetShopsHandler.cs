using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse;
using ShopyList.DataAccess.CQRS;
using ShopyList.DataAccess.CQRS.Queries.ShopsQueries;

namespace ShopyList.ApplicationServices.API.Handlers
{
    public class GetShopsHandler : IRequestHandler<GetShopsRequest, GetShopsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetShopsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetShopsResponse> Handle(GetShopsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetShopsQuery();
            var shops = await this.queryExecutor.Execute(query);
            var mappedShop = this.mapper.Map<List<Domain.Models.Shop>>(shops);

            var response = new GetShopsResponse()
            {
                Data = mappedShop
            };
            return response;
        }
    }
}
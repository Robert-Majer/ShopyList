using MediatR;

namespace ShopyList.ApplicationServices.API.Domain
{
    public class GetProductsRequest : IRequest<GetProtuctsResponse>
    {
        public string Name { get; set; }
    }
}
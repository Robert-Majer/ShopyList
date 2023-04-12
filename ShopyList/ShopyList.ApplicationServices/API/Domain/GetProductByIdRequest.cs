using MediatR;

namespace ShopyList.ApplicationServices.API.Domain
{
    public class GetProductByIdRequest : IRequest<GetProductByIdResponse>
    {
        public int ProductId { get; set; }
    }
}
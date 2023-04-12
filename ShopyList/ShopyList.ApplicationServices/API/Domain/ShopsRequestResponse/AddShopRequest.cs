using MediatR;

namespace ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse
{
    public class AddShopRequest : IRequest<AddShopResponse>
    {
        public string Name { get; set; }

        public string TypeOfSection { get; set; }

        public int SectionNumber { get; set; }
    }
}
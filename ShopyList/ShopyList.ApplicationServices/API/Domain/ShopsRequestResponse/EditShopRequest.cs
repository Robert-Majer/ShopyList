using MediatR;

namespace ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse
{
    public class EditShopRequest : IRequest<EditShopResponse>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //public string TypeOfSection { get; set; }

        //public int SectionNumber { get; set; }
    }
}
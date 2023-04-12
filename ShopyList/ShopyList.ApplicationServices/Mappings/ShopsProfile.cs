using AutoMapper;
using ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse;

namespace ShopyList.ApplicationServices.Mappings
{
    public class ShopsProfile : Profile
    {
        public ShopsProfile()
        {
            this.CreateMap<EditShopRequest, DataAccess.Entities.Shop>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

            this.CreateMap<AddShopRequest, DataAccess.Entities.Shop>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

            this.CreateMap<ShopyList.DataAccess.Entities.Shop, ShopyList.ApplicationServices.API.Domain.Models.Shop>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
        }
    }
}
using AutoMapper;
using ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse;

namespace ShopyList.ApplicationServices.Mappings
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            this.CreateMap<EditProductRequest, DataAccess.Entities.Product>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

            this.CreateMap<AddProductRequest, DataAccess.Entities.Product>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

            this.CreateMap<ShopyList.DataAccess.Entities.Product, ShopyList.ApplicationServices.API.Domain.Models.Product>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
        }
    }
}
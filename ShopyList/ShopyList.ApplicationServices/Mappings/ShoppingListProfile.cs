using AutoMapper;
using ShopyList.ApplicationServices.API.Domain.ShoppingListsRequestResponse;

namespace ShopyList.ApplicationServices.Mappings
{
    public class ShoppingListProfile : Profile
    {
        public ShoppingListProfile()
        {
            this.CreateMap<EditShoppingListRequest, DataAccess.Entities.ShoppingList>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

            this.CreateMap<AddShoppingListRequest, ShopyList.DataAccess.Entities.ShoppingList>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

            this.CreateMap<ShopyList.DataAccess.Entities.ShoppingList, ShopyList.ApplicationServices.API.Domain.Models.ShoppingList>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
        }
    }
}
using AutoMapper;
using ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse;
using ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse;
using ShopyList.ApplicationServices.API.Domain.UserRequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.ApplicationServices.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            this.CreateMap<ValidateUserRequest, DataAccess.Entities.User>()
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Username))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password));

            this.CreateMap<CreateUserRequest, DataAccess.Entities.User>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Username));

            this.CreateMap<ShopyList.DataAccess.Entities.User, ShopyList.ApplicationServices.API.Domain.Models.User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Username));
        }
    }
}

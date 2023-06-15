using MediatR;
using ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.ApplicationServices.API.Domain.UserRequestResponse
{
    public class GetUsersRequest : IRequest<GetUsersResponse>
    {
    }
}

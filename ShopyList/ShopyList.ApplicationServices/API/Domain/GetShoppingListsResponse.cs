using ShopyList.ApplicationServices.API.Domain.Models;
using ShopyList.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.ApplicationServices.API.Domain
{
    public class GetShoppingListsResponse : ResponseBase<List<Models.ShoppingList>>
    {
    }
}
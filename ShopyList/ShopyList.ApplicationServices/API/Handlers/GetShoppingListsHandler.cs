using MediatR;
using ShopyList.ApplicationServices.API.Domain;
using ShopyList.ApplicationServices.API.Domain.Models;
using ShopyList.DataAccess;
using ShopyList.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.ApplicationServices.API.Handlers
{
    public class GetShoppingListsHandler : IRequestHandler<GetShoppingListsRequest, GetShoppingListsResponse>
    {
        private readonly IRepository<DataAccess.Entities.ShoppingList> shoppingListRepository;

        public GetShoppingListsHandler(IRepository<DataAccess.Entities.ShoppingList> shoppingListRepository)
        {
            this.shoppingListRepository = shoppingListRepository;
        }

        public Task<GetShoppingListsResponse> Handle(GetShoppingListsRequest request, CancellationToken cancellationToken)
        {
            var shoppingLists = this.shoppingListRepository.GetAll();
            var domainShoppingLists = shoppingLists.Select(x => new Domain.Models.ShoppingList()
            {
                Id = x.Id,
                Name = x.Name,
            });

            var response = new GetShoppingListsResponse()
            {
                Data = domainShoppingLists.ToList(),
            };
            return Task.FromResult(response);
        }
    }
}
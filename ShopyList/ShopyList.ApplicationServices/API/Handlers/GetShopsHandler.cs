using MediatR;
using ShopyList.ApplicationServices.API.Domain;
using ShopyList.ApplicationServices.API.Domain.Models;
using ShopyList.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.ApplicationServices.API.Handlers
{
    public class GetShopsHandler : IRequestHandler<GetShopsRequest, GetShopsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Shop> shopRepository;

        public GetShopsHandler(IRepository<DataAccess.Entities.Shop> shopRepository)
        {
            this.shopRepository = shopRepository;
        }

        public Task<GetShopsResponse> Handle(GetShopsRequest request, CancellationToken cancellationToken)
        {
            var shops = this.shopRepository.GetAll();
            var domainShops = shops.Select(x => new Domain.Models.Shop()
            {
                Id = x.Id,
                Name = x.Name,
            });

            var response = new GetShopsResponse()
            {
                Data = domainShops.ToList(),
            };
            return Task.FromResult(response);
        }
    }
}
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
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProtuctsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Product> productRepository;

        public GetProductsHandler(IRepository<DataAccess.Entities.Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public Task<GetProtuctsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var products = this.productRepository.GetAll();
            var domainProducts = products.Select(x => new Domain.Models.Product()
            {
                Id = x.Id,
                Name = x.Name,
            });

            var response = new GetProtuctsResponse()
            {
                Data = domainProducts.ToList(),
            };
            return Task.FromResult(response);
        }
    }
}
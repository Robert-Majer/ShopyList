using Microsoft.AspNetCore.Mvc;
using ShopyList.DataAccess;
using ShopyList.DataAccess.Entities;

namespace ShopyList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> productRepository;

        public ProductController(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Product> GetAllProducts() => this.productRepository.GetAll();

        [HttpGet]
        [Route("{productId}")]
        public Product GetProductById(int productId) => this.productRepository.GetById(productId);
    }
}
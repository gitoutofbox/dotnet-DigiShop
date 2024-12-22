using AutoMapper;
using DigiShop.Models.Dtos;
using DigiShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigiShop.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDigiShopRepository digiShopRepository;
        private readonly IMapper mapper;

        public ProductsController(IDigiShopRepository _digiShopoRepository, IMapper _mapper)
        {
            digiShopRepository = _digiShopoRepository ?? throw new ArgumentNullException(nameof(_digiShopoRepository));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpGet("{productId}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDto>> GetProduct(int productId)
        {
            var product = await digiShopRepository.GetProduct(productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ProductDto>(product));
        }

        [HttpPost("{categoryId}")]
        public async Task<ActionResult<ProductDto>> AddProduct(int categoryId, ProductAddDto product)
        {
            var category = await digiShopRepository.GetCategory(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            var productToAdd = mapper.Map<Models.Product>(product);
            await digiShopRepository.AddProduct(categoryId, productToAdd);
            await digiShopRepository.SaveChanges();
            var createdProduct = mapper.Map<Models.Dtos.ProductDto>(productToAdd);
            return CreatedAtRoute("GetProduct", new {categoryId = categoryId, productId = createdProduct.Id}, createdProduct);
            
        }
    }
}

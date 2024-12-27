using AutoMapper;
using DigiShop.Models.Dtos;
using DigiShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DigiShop.Controllers
{
    [Route("api/categories/{categoryId}/products")]
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

        [HttpGet]
        public async Task<ActionResult<ProductDto>> GetProducts(int categoryId) {
            var products = await digiShopRepository.GetProducts(categoryId);

            return Ok(mapper.Map<IEnumerable<ProductDto>>(products));
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

        [HttpPost]
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
    
        [HttpPatch("{productId}")]
        public async Task<IActionResult> ParticalUpdate(int categoryId, int productId, JsonPatchDocument<ProductUpdateDto> patchDocument) 
        {
            var isCategoryExists = await digiShopRepository.IsCategoryExists(categoryId);
            if(!isCategoryExists) {
                return NotFound();
            }

            var product = await digiShopRepository.GetProduct(productId);
            if(product == null) {
                return NotFound();
            }


            var productToPatch = mapper.Map<ProductUpdateDto>(product);
            patchDocument.ApplyTo(productToPatch, ModelState);

            if(!ModelState.IsValid || !TryValidateModel(productToPatch)) {
                return BadRequest();
            }
            mapper.Map(productToPatch, product);
            await digiShopRepository.SaveChanges();
            return NoContent();
        }
    
    }
}

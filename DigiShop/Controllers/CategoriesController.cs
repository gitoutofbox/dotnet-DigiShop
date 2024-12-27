using AutoMapper;
using DigiShop.Models.Dtos;
using DigiShop.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DigiShop.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoroiesController : ControllerBase
    {
        private readonly IDigiShopRepository digiShopoRepository;
        private readonly IMapper mapper;

        public CategoroiesController(IDigiShopRepository _digiShopoRepository, IMapper _mapper)
        {
            digiShopoRepository = _digiShopoRepository ?? throw new ArgumentNullException(nameof(_digiShopoRepository));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories(bool includeProducts = false)
        {
            if(!includeProducts) {
            var categories = await digiShopoRepository.GetCategories();
            return Ok(mapper.Map<IEnumerable<Models.Dtos.CategoryDto>>(categories));
            } else {
                var categories = await digiShopoRepository.GetCategoriesWithProducts();
                return Ok(mapper.Map<IEnumerable<Models.Dtos.CategoryWithProductsDto>>(categories));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await digiShopoRepository.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryAddDto category)
        {
            var mappedCategory = mapper.Map<Models.Category>(category);
            await digiShopoRepository.AddCategory(mappedCategory);
            await digiShopoRepository.SaveChanges();
            return Ok(category);
        }

        [HttpPatch("{categoryId}")]
        public async Task<ActionResult> PartialUpdate(
            int categoryId, 
            JsonPatchDocument<CategoryUpdateDto> patchDocument) 
            {
            var category = await digiShopoRepository.GetCategory(categoryId);
            if(category == null) {
                return NotFound();
            }

            var categoryToPatch = mapper.Map<CategoryUpdateDto>(category);
            patchDocument.ApplyTo(categoryToPatch, ModelState);
            
            if(!ModelState.IsValid) {
                return BadRequest();
            }

            if(!TryValidateModel(categoryToPatch)) {
                return BadRequest();
            }
             mapper.Map(categoryToPatch, category);
             await digiShopoRepository.SaveChanges();
             return NoContent();
        }
    }
}

using AutoMapper;
using DigiShop.Dbcontext;
using DigiShop.Models;
using DigiShop.Models.Dtos;
using DigiShop.Services;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<CategoryDto>> GetCategories()
        {
            var categories = await digiShopoRepository.GetCategories();
            return Ok(mapper.Map<IEnumerable<Models.Dtos.CategoryDto>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await digiShopoRepository.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryAddDto category)
        {
            var mappedCategory = mapper.Map<Models.Category>(category);
            await digiShopoRepository.AddCategory(mappedCategory);
            await digiShopoRepository.SaveChanges();
            return Ok(category);
        }
    }
}

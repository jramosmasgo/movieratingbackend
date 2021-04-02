using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieRating.Features;
using MovieRating.Mapping.CategoryViewModel;
using MovieRating.Repository.IRepository;
using System.Threading.Tasks;

namespace MovieRating.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Categories categories;

        public CategoryController(ICategoryRepositoryAsync categoryRepositoryAsync, IMapper mapper)
        {
            categories = new Categories(mapper, categoryRepositoryAsync);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await categories.GetAllCategories());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await categories.GetCategoryById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryViewModel categoryViewModel)
        {
            return Ok(await categories.CreateCategory(categoryViewModel));
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieRating.Features;
using MovieRating.Mapping.MovieViewModel;
using MovieRating.Repository.IRepository;
using System.Threading.Tasks;

namespace MovieRating.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly Movies movies;

        public MovieController(IMapper mapper, IMovieRepositoryAsync movieRepository)
        {
            movies = new Movies(mapper, movieRepository);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await movies.GetAllMovies());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await movies.GetMovieById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieViewModel movieViewModel)
        {
            return Ok(await movies.CreateMovie(movieViewModel));
        }
    }
}

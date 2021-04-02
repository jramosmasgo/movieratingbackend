using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieRating.Features;
using MovieRating.Mapping.ActorViewModel;
using MovieRating.Repository.IRepository;
using System.Threading.Tasks;

namespace MovieRating.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly Actors actors;

        public ActorController(IMapper mapper,IActorRepositoryAsync actorRepositoryAsync)
        {
            actors = new Actors(mapper,actorRepositoryAsync);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await actors.GetAllActors());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await actors.GetActorById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateActorViewModel actorViewModel)
        {
            return Ok(await actors.CreateActor(actorViewModel));
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            return Ok(await actors.GetActorByName(name));
        }
    }
}

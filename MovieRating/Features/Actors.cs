using AutoMapper;
using MovieRating.Entities;
using MovieRating.Mapping.ActorViewModel;
using MovieRating.Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieRating.Features
{
    public class Actors
    {
        private readonly IActorRepositoryAsync _actorRepository;
        private readonly IMapper _mapper;

        public Actors(IMapper mapper,IActorRepositoryAsync actorRepository)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetActorViewModel>>> GetAllActors()
        {
            var actors = await _actorRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GetActorViewModel>>(actors);
            return new Response<IEnumerable<GetActorViewModel>>(result, "Operation Succesfully");
        }

        public async Task<Response<GetActorViewModel>> GetActorById(int id)
        {
            var actor = await _actorRepository.GetByIdAsync(id);
            var result = _mapper.Map<GetActorViewModel>(actor);
            return new Response<GetActorViewModel>(result, "Operation Succesfully");
        }

        public async Task<Response<GetActorViewModel>> CreateActor(CreateActorViewModel actorViewModel)
        {
            var actor = _mapper.Map<Actor>(actorViewModel);
            var result = await _actorRepository.AddAync(actor);
            return new Response<GetActorViewModel>(_mapper.Map<GetActorViewModel>(result), "Actor Created");
        }

        public async Task<Response<IEnumerable<GetActorViewModel>>> GetActorByName(string name)
        {
            var actor = await _actorRepository.GetAllAsyncFilters(x => x.Name.ToLower().Contains(name.ToLower()));
            var result = _mapper.Map<IEnumerable<GetActorViewModel>>(actor);
            return new Response<IEnumerable<GetActorViewModel>>(result, "Operation Succesfully");
        }
    }
}

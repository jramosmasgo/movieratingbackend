using AutoMapper;
using MovieRating.Entities;
using MovieRating.Mapping.MovieViewModel;
using MovieRating.Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieRating.Features
{
    public class Movies
    {
        private readonly IMovieRepositoryAsync _movieRepository;
        private readonly IMapper _mapper;

        public Movies(IMapper mapper,IMovieRepositoryAsync movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<Response<IEnumerable<GetMovieViewModel>>> GetAllMovies()
        {
            var categories = await _movieRepository.GetAllAsync(x => x.Category);
            var result = _mapper.Map<IEnumerable<GetMovieViewModel>>(categories);
            return new Response<IEnumerable<GetMovieViewModel>>(result, "Operation Succesfullly");
        }

        public async Task<Response<GetMovieViewModel>> GetMovieById(int id)
        {
            var category = await _movieRepository.GetByIdAsync(id, x => x.Category);
            var result = _mapper.Map<GetMovieViewModel>(category);
            return new Response<GetMovieViewModel>(result,"Operation Succesfully");
        }

        public async Task<Response<GetMovieViewModel>> CreateMovie(CreateMovieViewModel movieViewModel)
        {
            var movie = _mapper.Map<Movie>(movieViewModel);
            var result = await _movieRepository.AddAync(movie);
            return new Response<GetMovieViewModel>(_mapper.Map<GetMovieViewModel>(result), "Opration Succesfully");
        }
    }
}

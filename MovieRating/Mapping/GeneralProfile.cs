using AutoMapper;
using MovieRating.Entities;
using MovieRating.Mapping.ActorViewModel;
using MovieRating.Mapping.CategoryViewModel;
using MovieRating.Mapping.MovieViewModel;
using MovieRating.Mapping.Users;

namespace MovieRating.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Category, GetCategoryViewModel>().ReverseMap();
            CreateMap<CreateCategoryViewModel, Category>();

            CreateMap<Movie, GetMovieViewModel>().ReverseMap();
            CreateMap<CreateMovieViewModel, Movie>();

            CreateMap<Actor, GetActorViewModel>().ReverseMap();
            CreateMap<CreateActorViewModel, Actor>();

            CreateMap<User, GetUserViewModel>().ReverseMap();
            CreateMap<CreateUserViewModel, User>();
        }
    }
}

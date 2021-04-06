using AutoMapper;
using MovieRating.Entities;
using MovieRating.Mapping.Users;
using MovieRating.Repository.IRepository;
using System.Threading.Tasks;
using MovieRating.Helpers;

namespace MovieRating.Features
{
    public class Users
    {
        private readonly IUserRepositoryAsync _userRepository;
        private readonly IMapper _mapper;

        public Users(IUserRepositoryAsync userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Response<GetUserViewModel>> CreateUser(CreateUserViewModel userViewModel)
        {
            userViewModel.Password = userViewModel.Password.EncryptPassword();
            var user = _mapper.Map<User>(userViewModel);
            user.LoginSocialNetwork = false;
            var result = await _userRepository.AddAync(user);
            return new Response<GetUserViewModel>(_mapper.Map<GetUserViewModel>(result), "User Created");
        }

        public async Task<Response<GetUserViewModel>> Login(LoginViewModel credentials)
        {
            var user = await _userRepository.GetByFilter(x => x.Email == credentials.Email);
            if (user == null) return new Response<GetUserViewModel>(null, "User not fund",false);
            if (user.Password.DecryptPassword() != credentials.Password ) return new Response<GetUserViewModel>(null, "Password is not correct",false);
            return new Response<GetUserViewModel>(_mapper.Map<GetUserViewModel>(user), "Succesful login");
        }
    }
}

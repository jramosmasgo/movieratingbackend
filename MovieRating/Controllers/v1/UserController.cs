using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieRating.Features;
using MovieRating.Mapping.Users;
using MovieRating.Repository.IRepository;
using System.Threading.Tasks;

namespace MovieRating.Controllers.v1
{
    public class UserController : ControllerBase
    {
        private readonly Users users;

        public UserController(IUserRepositoryAsync userRepository,IMapper mapper)
        {
            users = new Users(userRepository,mapper);
        }

        [HttpPost("{register}")]
        public async Task<IActionResult> CreateUser(CreateUserViewModel createUserViewModel)
        {
            return Ok(await users.CreateUser(createUserViewModel));
        }

        [HttpPost("{login}")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            return Ok(await users.Login(loginViewModel));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NZ_Walks.Models.Dto.Auth;
using NZ_Walks.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NZ_Walks.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHandler _tokenHandler;

        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userRepository.AuthenticateAsync(loginRequest.Username, loginRequest.Password);

            if (user == null)
            {
                throw new Exception("Username or password is incorrect.");
            }

            return Ok(await _tokenHandler.CreateTokenAsync(user));
        }
    }
}


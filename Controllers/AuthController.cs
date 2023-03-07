using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using NZ_Walks.Models.Domain;
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
        private readonly IMapper _mapper;

        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler, IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
            _mapper = mapper;
        }

        [HttpPost("login")]
        [ActionName("LoginAsync")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userRepository.AuthenticateAsync(loginRequest.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
            {
                throw new Exception("Username or password is incorrect.");
            }

            return Ok(await _tokenHandler.CreateTokenAsync(user));
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest registerRequest)
        {
            registerRequest.Password = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password);

            var result = await _userRepository.RegisterAsync(_mapper.Map<User>(registerRequest));

            return CreatedAtAction(nameof(LoginAsync), new { }, _mapper.Map<Models.Dto.Auth.RegisterResponse>(result));
        }
    }
}


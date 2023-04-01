using AT.API.DTOs.Users;
using AT.Models;
using AT.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UsersController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserDto user)
        {
            var userResult = await _usersService.CreateUserAsync(_mapper.Map<User>(user), user.Password);

            if (userResult.Succeeded)
                return StatusCode(201);

            return BadRequest(userResult);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDto user)
        {
            var token = await _usersService.CreateTokenAsync(_mapper.Map<UserLogin>(user));

            if (token == null)
                return Unauthorized();
            
            return Ok(token);
        }
    }
}

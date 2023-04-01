using AT.API.DTOs.Authors;
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
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AuthorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService, IMapper mapper)
        {
            _authorsService = authorsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(await _authorsService.GetAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> Get(int id)
        {
            return Ok(_mapper.Map<AuthorDto>(await _authorsService.GetAsync(id)));
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Create(CreateAuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            return Ok(_mapper.Map<AuthorDto>(await _authorsService.CreateAsync(author)));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorDto>> Update(int id, UpdateAuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            author.Id = id;
            return Ok(_mapper.Map<AuthorDto>(await _authorsService.UpdateAsync(author)));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorDto>> Delete(int id)
        {
            return Ok(_mapper.Map<AuthorDto>(await _authorsService.DeleteAsync(id)));
        }
    }
}

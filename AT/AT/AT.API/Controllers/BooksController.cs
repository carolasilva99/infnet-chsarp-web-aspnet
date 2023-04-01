using AT.API.DTOs.Books;
using AT.Models;
using AT.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService, IMapper mapper)
        {
            _booksService = booksService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<BookDto>>(await _booksService.GetAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> Get(int id)
        {
            return Ok(_mapper.Map<BookDto>(await _booksService.GetAsync(id)));
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> Create(CreateBookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            return Ok(_mapper.Map<BookDto>(await _booksService.CreateAsync(book)));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookDto>> Update(int id, UpdateBookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            book.Id = id;
            return Ok(_mapper.Map<BookDto>(await _booksService.UpdateAsync(book)));
        }

        [HttpPatch("{bookId}/authors/{authorId}")]
        public async Task<ActionResult<BookDto>> AddAuthorToBook(int bookId, int authorId)
        {
            return Ok(_mapper.Map<BookDto>(await _booksService.AddAuthor(bookId, authorId)));
        }

        [HttpDelete("{bookId}/authors/{authorId}")]
        public async Task<ActionResult<BookDto>> DeleteAuthorFromBook(int bookId, int authorId)
        {
            return Ok(_mapper.Map<BookDto>(await _booksService.RemoveAuthor(bookId, authorId)));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BookDto>> Delete(int id)
        {
            return Ok(_mapper.Map<BookDto>(await _booksService.DeleteAsync(id)));
        }
    }
}

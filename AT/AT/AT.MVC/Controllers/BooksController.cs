using System.Collections;
using AT.Models;
using AT.MVC.Models.Authors;
using AT.MVC.Models.Books;
using AT.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AT.MVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBooksService _booksService;
        private readonly IAuthorsService _authorsService;

        public BooksController(IMapper mapper, IBooksService booksService, IAuthorsService authorsService)
        {
            _mapper = mapper;
            _booksService = booksService;
            _authorsService = authorsService;
        }

        // GET: BooksController
        public async Task<ActionResult> Index()
        {
            var books = await _booksService.GetAsync();
            return View(_mapper.Map<IEnumerable<BookViewModel>>(books));
        }

        // GET: BooksController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var book = await _booksService.GetAsync(id);
            return View(_mapper.Map<BookViewModel>(book));
        }

        // GET: BooksController/Create
        public async Task<ActionResult> Create()
        {
            var authors = await _authorsService.GetAsync();

            var authorsViewModel = _mapper.Map<IEnumerable<AuthorViewModel>>(authors);

            ViewBag.Authors = new MultiSelectList(authorsViewModel, "Id", "FullName");

            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBookViewModel createModel, int[] authorsId)
        {
            try
            {
                var authors = authorsId.Select(id => new CreateBookAuthorViewModel() { Id = id }).ToList();

                createModel.Authors = authors;

                await _booksService.CreateAsync(_mapper.Map<Book>(createModel));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var book = await _booksService.GetAsync(id);
            var otherAuthors = await _authorsService.GetAsync();
            var authors = book.Authors;

            ViewBag.Authors = authors;
            ViewBag.OtherAuthors = otherAuthors.Except(authors);

            return View(_mapper.Map<UpdateBookViewModel>(book));
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateBookViewModel updateBook)
        {
            try
            {
                await _booksService.UpdateAsync(_mapper.Map<Book>(updateBook));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var book = await _booksService.GetAsync(id);
            return View(_mapper.Map<BookViewModel>(book));
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _booksService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> RemoveAuthor(int bookId, int authorId)
        {
            var book = await _booksService.GetAsync(bookId);
            var author = await _authorsService.GetAsync(authorId);

            var removeAuthor = new RemoveAuthorViewModel()
            {
                Author = _mapper.Map<AuthorViewModel>(author),
                Book = _mapper.Map<BookViewModel>(book),
                AuthorId = author.Id,
                BookId = book.Id
            };

            return View(removeAuthor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveAuthor(RemoveAuthorViewModel removeAuthor)
        {
            try
            {
                await _booksService.RemoveAuthor(removeAuthor.BookId, removeAuthor.AuthorId);
                return RedirectToAction(nameof(Edit), new { id = removeAuthor.BookId });
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> AddAuthor(int bookId, int authorId)
        {
            var book = await _booksService.GetAsync(bookId);
            var author = await _authorsService.GetAsync(authorId);

            var removeAuthor = new AddAuthorViewModel()
            {
                Author = _mapper.Map<AuthorViewModel>(author),
                Book = _mapper.Map<BookViewModel>(book),
                AuthorId = author.Id,
                BookId = book.Id
            };

            return View(removeAuthor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddAuthor(AddAuthorViewModel addAuthor)
        {
            try
            {
                await _booksService.AddAuthor(addAuthor.BookId, addAuthor.AuthorId);
                return RedirectToAction(nameof(Edit), new { id = addAuthor.BookId });
            }
            catch
            {
                return View();
            }
        }
    }
}

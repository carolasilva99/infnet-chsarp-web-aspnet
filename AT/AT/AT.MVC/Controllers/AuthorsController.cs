using AT.Models;
using AT.MVC.Models.Authors;
using AT.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AT.MVC.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class AuthorsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IMapper mapper, IAuthorsService authorsService)
        {
            _mapper = mapper;
            _authorsService = authorsService;
        }

        // GET: AuthorsController
        public async Task<ActionResult> Index()
        {
            var authors = await _authorsService.GetAsync();
            return View(_mapper.Map<IEnumerable<AuthorViewModel>>(authors));
        }

        // GET: AuthorsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var author = await _authorsService.GetAsync(id);
            return View(_mapper.Map<AuthorViewModel>(author));
        }

        // GET: AuthorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateAuthorViewModel createAuthor)
        {
            try
            {
                await _authorsService.CreateAsync(_mapper.Map<Author>(createAuthor));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var author = await _authorsService.GetAsync(id);
            return View(_mapper.Map<UpdateAuthorViewModel>(author));
        }

        // POST: AuthorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateAuthorViewModel updateAuthor)
        {
            try
            {
                await _authorsService.UpdateAsync(_mapper.Map<Author>(updateAuthor));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var author = await _authorsService.GetAsync(id);
            return View(_mapper.Map<AuthorViewModel>(author));
        }

        // POST: AuthorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _authorsService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

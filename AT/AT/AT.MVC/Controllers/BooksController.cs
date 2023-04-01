﻿using AT.Models;
using AT.MVC.Models.Books;
using AT.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AT.MVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBooksService _booksService;

        public BooksController(IMapper mapper, IBooksService booksService)
        {
            _mapper = mapper;
            _booksService = booksService;
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBookViewModel createModel)
        {
            try
            {
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
    }
}

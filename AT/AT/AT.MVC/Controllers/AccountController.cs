using System.Security.Claims;
using AT.Models;
using AT.MVC.Models.Account;
using AT.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AT.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        // GET: AccountController/Create
        public AccountController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        public ActionResult Login(string ReturnUrl = "/books/index")
        {
            var objLoginModel = new LoginViewModel
            {
                ReturnUrl = ReturnUrl
            };
            return View(objLoginModel);
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel login)
        {
            try
            {
                var loginModel = _mapper.Map<UserEmailLogin>(login);
                var token = await _usersService.CreateTokenAsync(loginModel);

                if (token != null)
                {
                    HttpContext.Response.Cookies.Append("token", token.BearerToken,
                        new Microsoft.AspNetCore.Http.CookieOptions { Expires = token.ExpirationDate });

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, login.Email)
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = token.ExpirationDate,
                        IsPersistent = true,
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return LocalRedirect(login.ReturnUrl);
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Register()
        {
            return View(new CreateViewModel { ReturnUrl = "/" });
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(CreateViewModel createUser)
        {
            try
            {
                var createModel = _mapper.Map<User>(createUser);
                var result = await _usersService.CreateUserAsync(createModel, createUser.Password);

                if (result.Succeeded)
                    return RedirectToAction(nameof(Login));

                var messages = result.Errors.Select(e => e.Description);
                var errorMessages = string.Join(", ", messages);

                ViewBag.ErrorMessage = errorMessages;

                return View(createUser);
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(createUser);
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Logout()
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Logout(IFormCollection collection)
        {
            try
            {
                await HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }
    }
}

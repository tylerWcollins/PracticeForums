using PracticeForums.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PracticeForums.Services.Auth;
using PracticeForums.Services.User;
using PracticeForums.Services.Encryptor;

namespace PracticeForums.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;
        private IAuthService authService;

        //public AccountController(IUserService userservice, IAuthService authService)
        //{
        //    this.userService = new UserService(new SHA256Encryptor());
        //    this.authService = authService;
        //}

        public AccountController()
        {
            this.userService = new UserService(new SHA256Encryptor());
            this.authService = new AuthService(); 
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            bool isAuthenticated = this.userService.Authenticate(model.Username, model.Password);

            if (isAuthenticated)
            {
                this.authService.SetAuthCookie(model.Username, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                this.ModelState.AddModelError("", "Invalid username or password");

                return View(model);
            }
        }

        public ActionResult Logout()
        {
            this.authService.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {

            bool exists = this.userService.Exists(user.Username);

            if (exists)
            {
                this.ModelState.AddModelError("", "Username already exists");
                return View("Register");
            }

            try
            {
                this.userService.Register(user);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError("", "An error has occured, yes.");
                return View();
            }


            return RedirectToAction("Index", "Home");
        }

    }
}
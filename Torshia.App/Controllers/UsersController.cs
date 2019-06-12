using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Action;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Torshia.Models;
using Torshia.Services;

namespace Torshia.App.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet(Url = "/login")]
        public ActionResult Login()
        {
            return this.View();
        }

        [HttpPost(Url = "/login")]
        public ActionResult LoginConfirm()
        {
            string username = ((ISet<string>)this.Request.FormData["username"]).FirstOrDefault();
            string password = ((ISet<string>)this.Request.FormData["password"]).FirstOrDefault();

            User userFromDb = this.userService.GetUserByUsernameAndPassword(username, this.HashPassword(password));

            if (userFromDb == null)
            {
                return this.Redirect("/login");
            }

            this.SignIn(userFromDb.Id.ToString(), userFromDb.UserName, userFromDb.Email);

            return this.Redirect("/");
        }

        [HttpGet(Url = "/register")]
        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost(Url = "/register")]
        public ActionResult RegisterConfirm()
        {
            string username = ((ISet<string>)this.Request.FormData["username"]).FirstOrDefault();
            string password = ((ISet<string>)this.Request.FormData["password"]).FirstOrDefault();
            string confirmPassword = ((ISet<string>)this.Request.FormData["confirmPassword"]).FirstOrDefault();
            string email = ((ISet<string>)this.Request.FormData["email"]).FirstOrDefault();

            if (password != confirmPassword)
            {
                return this.Redirect("/register");
            }

            User user = new User
            {
                UserName = username,
                Password = this.HashPassword(password),
                Email = email
            };

            this.userService.CreateUser(user);

            return this.Redirect("/login");
        }

        [HttpGet(Url ="/logout")]
        public ActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }

        [NonAction]
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}

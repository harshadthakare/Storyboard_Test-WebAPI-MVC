using Storyboard.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Storyboard.WebApplication.Controllers
{
    public class AuthController : Controller
    {
        readonly string apiBaseAddress = ConfigurationManager.AppSettings["apiBaseAdreess"];
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiBaseAddress);
                    var postTask = client.PostAsJsonAsync<RegisterViewModel>("Auth/Register", register);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Login", "Auth");
                    }
                }
                ViewBag.Message = "User Details Saved";
                return View("Register");
            }
            else
            {
                return View("Register", register);
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseAddress);

                var postTask = client.PostAsJsonAsync<LoginViewModel>("Auth/Login", login);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    FormsAuthentication.SetAuthCookie(login.Email, false);
                    return RedirectToAction("Index", "Article");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Wrong Username and password combination !");
                }
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Auth");
        }
    }
}



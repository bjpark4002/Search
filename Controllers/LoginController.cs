using Itlize.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.UserRepo;
using Database;
using System.Diagnostics;


namespace Itlize.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify(Login login)
        {
            UserRepo user = new UserRepo(new Itlize_Project_1Entities());

            if (user.userLogin(login.User_Email, login.User_Password)) {
                return RedirectToAction("SearchPage", "Search");
            }

            return RedirectToAction("Login", "Login");
        }
    }
}
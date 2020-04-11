using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace StudentManagerMVC.Controllers.Login
{
    public class AdminLoginController : Controller
    {
        //
        // GET: /AdminLogin/

        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login()
        {
            Admins user = (Admins)TempData["user"];
            ViewData["Current"] ="欢迎您： "+ user.LoginName;
            return View();
        }

        [HttpPost]
        public ActionResult Admin(Admins user)
        {
            
            user = new LoginManager().Login(user);
            TempData["user"] = user;
            return RedirectToAction("Login","AdminLogin");
        }

        public ActionResult LoginedDemo()
        {
            Admins user = (Admins)Session["CurrentUser"];
            return PartialView("LoginedDemo",user);
        }

    }
}

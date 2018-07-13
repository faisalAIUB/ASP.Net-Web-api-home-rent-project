using ProjectEntity;
using ProjectInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectApp.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository repo;
        public HomeController(IUserRepository repo)
        {
            this.repo = repo;
        }
        // GET: Home
        public ActionResult Home()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            //user.Id = 1234;
            repo.Insert(user);
            return RedirectToAction("Home", "Home");
        }
    }
}
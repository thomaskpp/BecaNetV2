using BecaDotNet.ApplicationService;
using System;
using System.Web.Mvc;

namespace BecaDotNet.UI.MVC.RazorView.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string login, string password)
        {
            var svc = new UserAppService();
            var result = svc.AuthenticateUser(login, password);
            if (result.IsSuccess)
                return RedirectToAction("Index", "Home");

            ViewBag.LoginError = result.Messages;
            return View();
        }
    }
}
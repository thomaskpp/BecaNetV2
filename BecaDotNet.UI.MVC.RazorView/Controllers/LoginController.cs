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
            var svc = new UserAppSvcGeneric();
            var result = svc.Authenticate(login, password);
            if (result!=null)
                return RedirectToAction("Index", "Home");
            ViewBag.LoginError = "Usuário ou senha inválidos";
            return View();
        }
    }
}
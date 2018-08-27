using BecaDotNet.ApplicationService;
using BecaDotNet.Domain.Model;
using BecaDotNet.UI.MVC.RazorView.Models.Filter;
using BecaDotNet.UI.MVC.RazorView.Models.ViewModel;
using System.Web.Mvc;

namespace BecaDotNet.UI.MVC.RazorView.Controllers
{
    [CustomAuthorize]
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            var vm = new UserAccountViewModel();
            return View("UserControl", vm);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue && id.Value > 0)
                return View("UserControl", GetViewModelForEdit(id.Value));
            return RedirectToAction("New");
        }

        [HttpPost]
        public ActionResult SaveUser(UserAccountViewModel model)
        {
            if (!model.IsEdit)
                return CreateUserAction(model);
            return EditUserAction(model);
        }

        private ActionResult CreateUserAction(UserAccountViewModel model)
        {
            var createResult = DoCreateUser(model);
            if (createResult)
                return RedirectToAction("List");
            ViewBag.ErrorMessage = "Erro ao Criar o usuário";
            return View("UserControl",model);
        }


        private ActionResult EditUserAction(UserAccountViewModel model)
        {
            var updateResult = DoUpdateUser(model);
            if (updateResult)
                return RedirectToAction("List");
            ViewBag.ErrorMessage = "Erro ao Editar o usuário";
            return View("UserControl",model);
        }

        private bool DoCreateUser(UserAccountViewModel model)
        {
            var svc = new UserAppSvcGeneric();
            var created = svc.Create(model.GetEntity());
            return created.Id > 0;
        }

        private bool DoUpdateUser(UserAccountViewModel model)
        {
            var svc = new UserAppSvcGeneric();
            var updated = svc.Update(model.GetEntity());
            return updated != null;
        }

        private UserAccountViewModel GetViewModelForEdit(int id)
        {
            var user = new UserAppSvcGeneric().Get(id);
            return new UserAccountViewModel
            {
                EmailUsuario = user.Email,
                LoginUsuario = user.Login,
                NomeUsuario = user.Name,
                IsEdit = true,
                Id = id
            };
        }

    }
}
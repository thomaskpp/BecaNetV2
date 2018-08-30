using BecaDotNet.ApplicationService;
using BecaDotNet.UI.MVC.RazorView.Models.Filter;
using BecaDotNet.UI.MVC.RazorView.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BecaDotNet.UI.MVC.RazorView.Controllers
{
    [CustomAuthorize]
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult List()
        {
            return View(GetClientViewModel());
        }

        [HttpGet]
        public ActionResult New()
        {
            return View(new ClientViewModel());
        }

        [HttpPost]
        public ActionResult Create(ClientViewModel model)
        {
            var svc = new ClientAppService();
            var toCreate = model.GetModel();
            var result = svc.Create(toCreate);
            if (result.Id > 0)
                return RedirectToAction("Index");
            ViewBag.ErrorMessage = "Erro ao criar o Cliente";
            return View("New", model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id <= 0)
                return RedirectToAction("Index");
            var svc = new ClientAppService();
            var model = svc.Get(id);
            if(model == null)
                return RedirectToAction("Index");
            var vm = new ClientViewModel
            {
                CnpjCliente = model.Cnpj,
                Id = model.Id,
                NomeCliente = model.ClientName,
                NomeContatoCliente = model.ContactName
            };
            return View(vm);

        }



        private static IEnumerable<ClientViewModel> GetClientViewModel()
        {
            var resultList = new List<ClientViewModel>();
            var svc = new ClientAppService();
            var result = svc.FindBy(null).ToList();
            if (result.Count > 0)
                foreach (var item in result)
                    resultList.Add(
                        new ClientViewModel
                        {
                            Id = item.Id,
                            CnpjCliente = item.Cnpj,
                            NomeCliente = item.ClientName,
                            NomeContatoCliente = item.ContactName
                        }
                    );
            return resultList;
        }
    }
}
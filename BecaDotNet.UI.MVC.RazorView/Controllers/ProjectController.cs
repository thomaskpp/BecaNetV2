using BecaDotNet.ApplicationService;
using BecaDotNet.Domain.Model;
using BecaDotNet.UI.MVC.RazorView.Models.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BecaDotNet.UI.MVC.RazorView.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var lst = GetListFromModel(new ProjectAppService().FindBy(null));
            return View("List", lst);
        }

        private IEnumerable<ProjectViewModel> GetListFromModel(IEnumerable<Project> list)
        {
            var result = new List<ProjectViewModel>();
            foreach (var i in list)
                result.Add(new ProjectViewModel
                {
                    Id = i.Id,
                    ProjectName = i.ProjectName,
                    StartDate = i.StartDate,
                    EndDate = i.EndDate
                });
            return result;
        }


        // GET: Project/Create
        public ActionResult Create()
        {
            return View(new ProjectViewModel());
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(ProjectViewModel model)
        {
            try
            {
                var result = new ProjectAppService().Create(model.GetEntity());
                if (result != null && result.Id > 0)
                    return RedirectToAction("Index");

                ViewBag.ErrorMessage = "Erro ao inserir Projeto";
                return View();
            }
            catch
            {
                ViewBag.ErrorMessage = "Erro ao inserir Projeto";
                return View();
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
                return RedirectToAction("Index");
            var entity = new ProjectAppService().Get(id);
            if (entity == null)
                return RedirectToAction("Index");

            var model = GetModelFromEntity(entity);

            return View(model);
        }

        private ProjectViewModel GetModelFromEntity(Project entity)
        {
            return new ProjectViewModel
            {
                Id = entity.Id,
                ClientId = entity.ClientId,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                ProjectName = entity.ProjectName
            };
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using BecaDotNet.ApplicationService;
using BecaDotNet.Domain.Model;
using BecaDotNet.UI.MVC.WebApi.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace BecaDotNet.UI.MVC.WebApi.Controllers
{

    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {

        [HttpGet]
        [Route("get")]
        public IHttpActionResult Get(int? id)
        {
            var svc = new UserAppSvcGeneric();
            if (id.HasValue && id.Value < 0)
                return BadRequest();

            if (id.HasValue && id.Value > 0)
            {
                var resultSingle = svc.Get(id.Value);
                if (resultSingle.Id == 0)
                    return NotFound();
                return Ok(resultSingle);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("list")]
        public IHttpActionResult Get(User filter)
        {
            var svc = new UserAppSvcGeneric();
            var result = svc.FindBy(filter);
            if (result == null || result.Count() == 0)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Post(UserViewModel model)
        {
            if (string.IsNullOrEmpty(model.login) ||
                string.IsNullOrEmpty(model.name) ||
                string.IsNullOrEmpty(model.email) ||
                string.IsNullOrEmpty(model.password))
                return BadRequest();

            try
            {
                var svc = new UserAppSvcGeneric();
                var toCreate = model.GetUser();
                var result = svc.Create(toCreate);
                if (result.Id > 0)
                    return Ok(result);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();
            var svc = new UserAppSvcGeneric();
            var user = svc.Get(id);
            if (user == null)
                return NotFound();

            var result = svc.Delete(id);
            return result ? StatusCode(HttpStatusCode.NoContent) :
                            StatusCode(HttpStatusCode.InternalServerError);
        }

        [HttpPatch]
        [Route("update")]
        public IHttpActionResult Patch(UserViewModel model)
        {
            if (!model.id.HasValue || model.id.Value <= 0)
                return BadRequest();
            var svc = new UserAppSvcGeneric();
            var toUpdate = svc.Get(model.id.Value);
            if (toUpdate == null)
                return NotFound();
            try
            {
                toUpdate.Name = model.name;
                var result = svc.Update(toUpdate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}

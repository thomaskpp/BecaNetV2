using BecaDotNet.ApplicationService;
using BecaDotNet.Domain.Model;
using BecaDotNet.UI.MVC.WebApiV2.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BecaDotNet.UI.MVC.WebApiV2.Controllers
{
    [EnableCors(origins:"http://localhost:8080",headers:"*",methods:"GET,POST,PATCH,DELETE")]
    public class UserController : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get(int? id)
        {
            var svc = new UserAppSvcGeneric();
            if (id.HasValue && id.Value < 0)
                return BadRequest();

            if (id.HasValue && id.Value > 0)
            {
                var resultSingle = svc.Get(id.Value);
                if (resultSingle == null)
                    return NotFound();
                return Ok(resultSingle);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("api/user/list")]
        public IHttpActionResult List(string name, int? usertypeid)
        {
            var svc = new UserAppSvcGeneric();
            var filterObj = new User
            {
                Name = name,
                UserTypeId = usertypeid ?? 0
            };

            var result = svc.FindBy(filterObj);

            if (result == null || result.Count() == 0)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
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

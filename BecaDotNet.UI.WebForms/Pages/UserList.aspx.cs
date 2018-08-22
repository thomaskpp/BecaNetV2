using BecaDotNet.ApplicationService;
using BecaDotNet.Domain.Model;
using System;

namespace BecaDotNet.UI.WebForms.Pages
{
    public partial class UserList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDataForGridView();
        }

        private void LoadDataForGridView()
        {
            var userAppService = new UserAppService();
            var result = userAppService.GetUser(new User());
            if (result.IsSuccess)
            {
                gvUserList.DataSource = ((ResultModelMany<User>)result).ResultObject;
                gvUserList.DataBind();
            }
        }

        protected string GetSuperior(int? superiorId)
        {
            if (!superiorId.HasValue)
                return "N/A";

            var result = new UserAppService().GetUser(superiorId.Value);
            return ((ResultModelSingle<User>)result).ResultObject.Name;
        }
    }
}
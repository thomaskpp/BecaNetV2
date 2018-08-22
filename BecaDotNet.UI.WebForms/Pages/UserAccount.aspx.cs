using BecaDotNet.ApplicationService;
using BecaDotNet.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BecaDotNet.UI.WebForms.Pages
{
    public partial class UserAccount : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DoRegister(object s, EventArgs e)
        {
            var userAppService = new UserAppService();
            var newUser = new User
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Login = txtLogin.Text,
                Password = txtPassword.Text
            };
            var resultUser = userAppService.RegisterUser(newUser);
            if (resultUser.IsSuccess)
                Response.Redirect("~/Pages/UserList.aspx");
        }
    }
}
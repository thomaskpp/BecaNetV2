using BecaDotNet.ApplicationService;
using BecaDotNet.Domain.Model;
using System;
using System.Collections.Generic;

namespace BecaDotNet.UI.WebForms.Pages
{
    public partial class UserList : BasePage
    {
        protected List<User> ResultSet
        {
            get
            {
                if (Session["ResultSet"] == null)
                    Session["ResultSet"] = new List<User>();
                return (List<User>)Session["ResultSet"];
            }
            set => Session["ResultSet"] = value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
            LoadDataForGridView();
        }

        private void LoadDataForGridView()
        {
            gvUserList.DataSource = ResultSet;
            gvUserList.DataBind();
        }

        private void LoadData()
        {
            var userAppService = new UserAppService();
            var result = userAppService.GetUser(new User());
            if (result.IsSuccess)
                ResultSet = ((ResultModelMany<User>)result).ResultObject;
        }

        protected string GetSuperior(int? superiorId)
        {
            if (!superiorId.HasValue)
                return "N/A";

            var result = new UserAppService().GetUser(superiorId.Value);
            return ((ResultModelSingle<User>)result).ResultObject.Name;
        }

        protected void gvUserList_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditUser")
            {
                var itemIndex = int.Parse(e.CommandArgument.ToString());
                var item = ResultSet[itemIndex];
                Response.Redirect($"~/Pages/UserAccount.aspx?UserId={item.Id}");
                //Para quem for utilizar a mesma página de cadastro para editar
                Response.Redirect($"~/Pages/UserEdit.aspx?UserId={item.Id}");
                //Para quem for utilizar a outra página para editar



            }
        }
    }
}
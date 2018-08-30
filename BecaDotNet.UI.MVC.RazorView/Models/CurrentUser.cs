using BecaDotNet.Domain.Model;
using System.Web;

namespace BecaDotNet.UI.MVC.RazorView.Models
{
    public static class CurrentUser
    {
        public static User UserData
        {
            get =>
                HttpContext.Current.Session["CurrentUser"] == null ?
                    new User() :
                (User)HttpContext.Current.Session["CurrentUser"];
        }
    }
}

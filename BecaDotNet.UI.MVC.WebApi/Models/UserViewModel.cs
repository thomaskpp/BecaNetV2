using BecaDotNet.Domain.Model;

namespace BecaDotNet.UI.MVC.WebApi.Models
{
    public class UserViewModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int? superior_id { get; set; }
        public int? id { get; set; }

        public User GetUser()
        {
            return new User()
            {
                Name = name,
                Email = email,
                Login = login,
                Password = password,
                SuperiorId = superior_id,
                Id = id ?? 0
            };
        }

    }
}
using BecaDotNet.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace BecaDotNet.UI.MVC.RazorView.Models.ViewModel
{
    public class UserAccountViewModel
    {
        [Required(ErrorMessage ="Informe o Nome")]
        [Display(Name ="Nome")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Informe o Login")]
        [Display(Name = "Login")]
        public string LoginUsuario { get; set; }

        [Required(ErrorMessage = "Informe o E-Mail")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-Mail inválido")]
        public string EmailUsuario { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string SenhaUsuario { get; set; }

        public bool IsEdit { get; set; }
        public int Id { get; set; }


        public User GetEntity()
        {
            return new User
            {
                Email = EmailUsuario,
                Name = NomeUsuario,
                Login = LoginUsuario,
                Password = SenhaUsuario,
                Id = Id
            };
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace BecaDotNet.UI.MVC.RazorView.Models.ViewModel
{
    public class UserListViewModel  : UserAccountViewModel
    {
        public string NomeSuperior { get; set; }
        public DataType DataCadastro { get; set; }
        public bool UsuarioAtivo { get; set; }
        public string DescTipoUsuario { get; set; }
    }
}
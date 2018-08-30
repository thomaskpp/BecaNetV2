using BecaDotNet.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace BecaDotNet.UI.MVC.RazorView.Models.ViewModel
{
    public class ClientViewModel
    {
        [Display(Name="Nome do Cliente")]
        [Required]
        public string NomeCliente { get; set; }
        [Display(Name = "CNPJ do Cliente")]
        [Required]
        public long CnpjCliente { get; set; }
        [Display(Name = "Nome do Contato no Cliente")]
        [Required]
        public string NomeContatoCliente { get; set; }

        public int Id { get; set; }
        public bool IsEdit { get; set; }

        public Client GetModel()
        {
            return new Client
            {
                Id = Id,
                ClientName = NomeCliente,
                ContactName = NomeContatoCliente,
                Cnpj = CnpjCliente
            };
        }
    }
}
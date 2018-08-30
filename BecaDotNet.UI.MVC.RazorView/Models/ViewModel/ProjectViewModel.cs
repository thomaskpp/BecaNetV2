using BecaDotNet.ApplicationService;
using BecaDotNet.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BecaDotNet.UI.MVC.RazorView.Models.ViewModel
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public bool IsEdit { get; set; }
        [Display(Name = "Nome do Projeto")]
        [Required]
        public string ProjectName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Display(Name = "Data Início")]
        [Required]
        public string DataInicio
        {
            get => StartDate.ToString("yyyy-MM-dd");
            set
            {
                DateTime.TryParse(value, out DateTime newDate);
                if (newDate.Date == DateTime.MinValue.Date)
                    newDate = DateTime.Now.Date;
                StartDate = newDate;
            }
        }

        [Display(Name = "Data Fim")]
        public string DataFim
        {
            get => EndDate.HasValue ? EndDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            set
            {
                DateTime.TryParse(value, out DateTime newDate);
                EndDate = newDate.Date == DateTime.MinValue.Date ? null : (DateTime?)newDate;
            }
        }

        [Display(Name ="Cliente")]
        [Required(ErrorMessage ="Selecionar o cliente")]
        public int ClientId { get; set; }

        public IEnumerable<SelectListItem> DdlClientList { get; set; }

        public ProjectViewModel()
        {
            var clientList = new ClientAppService().FindBy(null);
            DdlClientList = HelperForDropdown<Client>.GetDropDownListFrom(clientList, "ClientName");
        }

        public Project GetEntity()
        {
            return new Project
            {
                ClientId = ClientId,
                ProjectName = ProjectName,
                StartDate = StartDate,
                EndDate = EndDate
            };
        }
    }
}
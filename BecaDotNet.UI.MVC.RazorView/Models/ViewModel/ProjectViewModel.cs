using BecaDotNet.Domain.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace BecaDotNet.UI.MVC.RazorView.Models.ViewModel
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public bool IsEdit { get; set; }
        [Display(Name ="Nome do Projeto")]
        [Required]
        public string ProjectName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Display(Name ="Data Início")]
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
        public string DataFim {
            get => EndDate.HasValue ? EndDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            set {
                DateTime.TryParse(value, out DateTime newDate);
                EndDate = newDate.Date == DateTime.MinValue.Date ? null :(DateTime?)newDate;
            }
        }
    }
}
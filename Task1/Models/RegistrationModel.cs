using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Task1.Models
{
    public class RegistrationModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly WantedDate { get; set; }
        public DateOnly CurrentDate { get; } = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        [Required]
        [Display(Name = "Product")]
        public string SelectedValue { get; set; }
        public List<SelectListItem> Options { get; set; } = new(){
                new SelectListItem("JavaScript", "js"),
                new SelectListItem("C#", "cs"),
                new SelectListItem("Java", "java"),
                new SelectListItem("Python", "py"),
                new SelectListItem("Основи", "основи"),
            };
    }
}

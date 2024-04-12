using System.ComponentModel.DataAnnotations;

namespace Task1
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
        public DateOnly CurrentDate { get; } = new (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
    }
}

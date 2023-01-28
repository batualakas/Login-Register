using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        [Display(Name ="İsim")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Soyisim")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Email Adresi")]
        [Required]
        public string Email { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string FirstName { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Display(Name = "Şifre")]
        
      
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Compare(nameof(Password), ErrorMessage = "Şifreler birbiri ile eşleşmiyor. Lütfen aynı şifreyi tekrar giriniz")]
        public string PasswordConfirm { get; set; }
    }
}

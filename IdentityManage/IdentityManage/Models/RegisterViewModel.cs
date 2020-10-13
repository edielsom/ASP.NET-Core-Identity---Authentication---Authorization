using System.ComponentModel.DataAnnotations;

namespace IdentityManager.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ser pelo menos {2} caracteres longos.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "A senha não se correspondem.")]
        public string ConfirmPassword { get; set; }

        public string Name { get; set; }

    }
}

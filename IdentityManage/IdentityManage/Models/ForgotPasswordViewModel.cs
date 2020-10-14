using System.ComponentModel.DataAnnotations;

namespace IdentityManager.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "O campo Email não é um endereço de email válido")]
        [EmailAddress]
        public string Email { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace IdentityManager.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo Email não é um endereço de email válido")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me?")]
        public bool RememberMe { get; set; }
    }
}

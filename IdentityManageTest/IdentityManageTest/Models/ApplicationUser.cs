using Microsoft.AspNetCore.Identity;

namespace IdentityManager
{
    public class ApplicationUser : IdentityUser
    {
        public string Celular { get; set; }
        public string Cidade { get; set; }
        public string BancoDados { get; set; }
        
    }
}

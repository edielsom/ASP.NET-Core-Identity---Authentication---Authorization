using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.Models
{
    public class TwoFactorAuthenticationViewModel
    {
        //Usado para o login
        public string Code { get; set; }

        //Usado para registrar / signup
        public string Token { get; set; }
        public string QRCodeUrl { get; set; }
    }
}

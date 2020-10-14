using IdentityManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace IdentityManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        public IActionResult Register(string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            RegisterViewModel registerViewModel = new RegisterViewModel();
            return View(registerViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                //Cria uma instância de uma usuário
                var user = new ApplicationUser
                { UserName = model.Email, Email = model.Email, Name = model.Name, EmailConfirmed = true, LockoutEnabled = true, AccessFailedCount = 0 };

                //Faz a operação de inserção
                var result = await _userManager.CreateAsync(user, model.Password);

                //Se conseguir cadastrar retorna sucesso.
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                //Adiciona todos os erros encontrados.
                AddErrors(result);
            }
            return View(model);
        }


        public IActionResult Login(string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                //Faz a consulta das credenciais
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: true);


                //Usuário Localizado
                if (result.Succeeded)
                {
                    return LocalRedirect(returnurl);
                }

                //Usuário Bloqueado
                if (result.IsLockedOut)
                {
                    return View("Lockout");
                }
                else
                {
                    //Retorna a view e o erro.
                    ModelState.AddModelError(string.Empty, "Login inválido.");
                    return View(model);
                }
               
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            //Faz logoff
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if(user == null)
                {
                    RedirectToAction("ForgotPasswordConfirmation");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackurl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);

                await _emailSender.SendEmailAsync(model.Email, "Resetar senha - Identity Manager",
                    "Por favor, resete sua senha clicando no link aqui: <a href=\"" + callbackurl + "\">link</a>");

                return RedirectToAction("ForgotPasswordConfirmation");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        private void AddErrors(IdentityResult result)
        {
            //Adiciona todos os erros
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}

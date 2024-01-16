using AutoMapper;
using EmailService;
using GestaoFluxoFinanceiro.Aplicacao.Data;
using GestaoFluxoFinanceiro.Aplicacao.Extensions;
using GestaoFluxoFinanceiro.Aplicacao.ViewModels.Acesso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoFluxoFinanceiro.Aplicacao.Controllers.Acesso
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AppContexto _identityContexto;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;


        public AccountController(UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager,
                              IMapper mapper, 
                              IEmailSender emailSender,
                              AppContexto identityContexto)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _identityContexto = identityContexto;
            _emailSender = emailSender;
            _mapper = mapper;
        }
        
        [ClaimsAuthorize("Adm", "Ger")]
        public async Task<IActionResult> Index()
        {
            var logins = _mapper.Map<IEnumerable<UsuariosViewModel>>(await _identityContexto.Users.ToListAsync());
            return View(logins);
        }
        
        [Route("registar-novo-usuario")]
        [ClaimsAuthorize("Adm", "Ger")]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [Route("registar-novo-usuario")]
        [ClaimsAuthorize("Adm", "Ger")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.User,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                  
                    TempData["Sucesso"] = "Usuário e senha criados!";
                    await _userManager.AddToRoleAsync(user, "Visual");

                    return View();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }              

            }
            return View(model);
        }
        
        [HttpGet]
        [AllowAnonymous]
        [Route("fazer-login")]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        [Route("fazer-login")]
        public async Task<IActionResult> Login(LoginViewModel userViewModel)
        {
            ModelState.Remove("Email");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userViewModel.User, userViewModel.Password, userViewModel.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Login não foi possível!");

            }
            return View(userViewModel);
        }
        
        [ClaimsAuthorize("Adm", "Visual")]
        [Route("mudar-senha")]
        public IActionResult ResetPassword()
        {
            return View();
        }
        
        [Route("mudar-senha")]
        [ClaimsAuthorize("Adm", "Visual")]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel entidadeViewModel)
        {
            if (!ModelState.IsValid)
                return View(entidadeViewModel);

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null)
                return View(entidadeViewModel);

            var resetPassResult = await _userManager.ChangePasswordAsync(user, entidadeViewModel.Password, entidadeViewModel.NewPassword);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return View();
            }

            TempData["Sucesso"] = "Alteração realizada!";
            return View("ResetPasswordConfirmation", entidadeViewModel);
        }
        
        [Route("mudar-senha-email")]
        [AllowAnonymous]
        [HttpGet]
        public  IActionResult PasswordEmail(string token, string email)
        {
            var entidadeViewModel = new ResetPasswordEmailViewModel { Token = token, Email = email };
            if (entidadeViewModel == null)
            {
                return RedirectToAction("Index");
            }
            return View("ResetPasswordEmail",entidadeViewModel);
        }
        
        [Route("confirmar-mudar-senha-email")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ResetPasswordEmail(ResetPasswordEmailViewModel entidadeViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var user = await _userManager.FindByEmailAsync(entidadeViewModel.Email);
            if (user == null)
                RedirectToAction(nameof(ResetPasswordEmail));

            var resetPassResult = await _userManager.ResetPasswordAsync(user, entidadeViewModel.Token, entidadeViewModel.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return View();
            }

            TempData["Sucesso"] = "Alteração realizada!";
            return View("ResetPasswordConfirmation", entidadeViewModel);
        }     
        
        [AllowAnonymous]
        [Route("esqueceu-senha")]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        
        [AllowAnonymous]
        [Route("esqueceu-senha")]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel entidadeViewModel)
        {
            if (!ModelState.IsValid)
                return View(entidadeViewModel);

            var user = await _userManager.FindByEmailAsync(entidadeViewModel.Email);
            if (user == null)
                return RedirectToAction(nameof(ForgotPasswordConfirmation));

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callback = Url.Action(nameof(PasswordEmail), "Account", new { token, email = user.Email }, Request.Scheme);

            var message = new Message(new string[] { user.Email }, "Reset password token", callback, null);
            await _emailSender.SendEmailAsync(message);

            return RedirectToAction(nameof(ForgotPasswordConfirmation));            
        }
        
        [AllowAnonymous]
        [Route("confirmacao-email-senha")]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        
        [AllowAnonymous]
        [Route("email-enviado")]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        
        [Route("sair")]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}

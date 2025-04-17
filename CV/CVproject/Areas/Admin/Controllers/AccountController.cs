using CVproject.Helpers.Email;
using CVproject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace CVproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        ////UserManager : CRUD Oprations ==> Users
        ////SignInManager :  ==> Users Authentication
        ///
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        //private readonly IEmailSender _emailSender;
        //IMapper _mapper;
        IEmailHelper emailHelper;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IEmailHelper emailHelper)
        {
            this.userManager=userManager;
            this.signInManager=signInManager;
            this.emailHelper=emailHelper;
        }



        public IActionResult Register()
        {
            //// Add Users
            
            return View();
        }
        [HttpPost]    
        public async Task<IActionResult> Register(RegisterViewModel model) /*asynchromas programming*/
        {
            //// Add Users
           
            IdentityUser obj = new IdentityUser();
            obj.Email = model.Email;    
            obj.UserName = model.UserName;
            var result = await userManager.CreateAsync(obj, model.Password);

            if (result.Succeeded){

               await signInManager.SignInAsync(obj,false);
               return RedirectToAction("Index", "Home");   
               
            }

            return View();
        }
        


        public IActionResult Login()
        {
            //// Chek Users
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //// Chek Users

            //// في حال بدي اعمل تسجيل تخول باستخدام ال Email
            //userManager.FindByEmailAsync(model.Email);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "data is filled");
                return View(model);
            }
            var result = await signInManager.PasswordSignInAsync(model.UserName,model.Password,false,false);
            if (result.Succeeded){
 
                return RedirectToAction("Index", "Home");
            }
            else {
                ModelState.AddModelError("", "Please Ensure that User and pass are correct");
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
        
            await signInManager.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }


        ////////////////////////////////////


        
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(forgotPasswordModel);
            var user = await userManager.FindByEmailAsync(forgotPasswordModel.Email);
            if (user == null)
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var callback = Url.Action(nameof(ResetPassword), "Account", new { token, email = user.Email }, Request.Scheme);
          
            string htmlMessage = $"To reset your password <a href='{callback}'>Please Click Here </a>";
            emailHelper.SendEmailHTMLBody(forgotPasswordModel.Email, "Forget Password URL", htmlMessage);//.SendEmailAsync(message);
            return RedirectToAction(nameof(ForgotPasswordConfirmation));

            //if (!ModelState.IsValid)
            //    return View(forgotPasswordModel);

            //var user = await userManager.FindByEmailAsync(forgotPasswordModel.Email);
            //if (user == null)
            //    return RedirectToAction(nameof(ForgotPasswordConfirmation));

            //var token = await userManager.GeneratePasswordResetTokenAsync(user);
            //var callback = Url.Action(nameof(ResetPassword), "Account", new { token, email = user.Email }, Request.Scheme);

            ////var message = new Message(new string[] { user.Email }, "Reset password token", callback, null);
            ////await emailHelper.SendEmailAsync(message);

            //string htmlMessage = $"To reset your password <a href='{callback}'>Please Click Here </a>";
            //emailHelper.SendEmailHTMLBody(forgotPasswordModel.Email, "Forget Password URL", htmlMessage);//.SendEmailAsync(message);


            //return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }


        /////////////////////////////////////




    
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordViewModel { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(resetPasswordModel);
            var user = await userManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
                RedirectToAction(nameof(ResetPasswordConfirmation));
            var resetPassResult = await userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View();
            }
            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }

        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }












    }
}

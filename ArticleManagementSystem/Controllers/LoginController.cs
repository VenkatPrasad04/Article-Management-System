using AMS.Models.LoginModels;
using AMS.ServiceLayer.ServiceInterfaceImpl;
using AMS.ServiceLayer.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace ArticleManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;
        private readonly IForgotPasswService _forgotPasswService;

        // Constructor with dependency injection for both services
        public LoginController(ILoginService loginService, IRegisterService registerService, IForgotPasswService forgotPasswService)
        {
            _loginService = loginService;
            _registerService = registerService;
            _forgotPasswService = forgotPasswService;
        }
        public IActionResult Index()
        {
            return View("Login");
        }
        [HttpPost]
        public IActionResult ValidateUser(LoginViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                string output = _loginService.GetUserName(model);
                
                
                if (!string.IsNullOrEmpty(output))
                {
                    HttpContext.Session.SetString("UserId", output);
                    // Redirect to home on successful login
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password");
                    ViewData["LoginFailed"] = true;
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }

        }


        // ---------------------------------Register Controller---------------------------------------------------
        public IActionResult Register()
        {
            // Assuming you have a RegisterViewModel defined
            RegisterViewModel registerModel = new RegisterViewModel();
            return View(registerModel);
        }

        [HttpPost]
        public IActionResult ValidateRegister(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {             
                    _registerService.RegisterUser(model);                
                    return RedirectToAction("Index", "Login");
                }
                catch (Exception ex)
                {
                    // Handle exceptions, log errors, or provide a user-friendly message
                    ModelState.AddModelError(string.Empty, "An error occurred while processing your registration.");
                    return View("Register", model);
                }
            }
            else
            {
                // Model validation failed, return the registration view with errors
                return View("Register", model);
            }
        }

        //-----------------------------------------ForgotPassword---------------------------------------------
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            // Assuming you have a ViewModel defined
            ForgotpasswordViewModel forgotpasswordModel = new ForgotpasswordViewModel();
            return View();
        }

        [HttpPost]
        public IActionResult ValidateForgotPassword(ForgotpasswordViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    
                    _forgotPasswService.ResetPassword(model);

                   
                    return RedirectToAction("Index", "Login");
                }
                catch (Exception ex)
                {
                    
                    ModelState.AddModelError(string.Empty, "An error occurred while processing.");
                    return View("ForgotPassword", model);
                }
            }
            else { return View("ForgotPassword", model); }
        }

    }
}

using IdentityWithCode.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityWithCode.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> Register(registerViewModel model,string ReturnUrl=null)
        {
            if (ModelState.IsValid)
            {
                ReturnUrl = ReturnUrl ?? Url.Content("~/");
                var user = new IdentityUser()
                {
                    Email = model.Email,
                    UserName = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                
                var roleResult = await _userManager.AddToRoleAsync(user, "Manager");

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("index", "Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
              
            }
            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Login(loginViewModel model,string ReturnUrl=null)
        {
            ReturnUrl = ReturnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                     
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                
            }
            ModelState.AddModelError("", "model hatası");
            return View(model);
        }

        public async Task<IActionResult> SignOut()
        {
             await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied(string ReturnUrl = null)
        {
           
            return RedirectToAction("Login",new {ReturnUrl=ReturnUrl });

        }
    }
}

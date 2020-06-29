using System;
using System.Threading.Tasks;
using EstateApp.Data.Entities;
using EstateApp.Web.Interfaces;
using EstateApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EstateApp.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountsService _accountsService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountsController(
            IAccountsService accountsService, SignInManager<ApplicationUser> signInManager)
        {
            _accountsService = accountsService;
            _signInManager = signInManager;
        }
        [HttpGet]
         public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if(!ModelState.IsValid) return View();
            throw new NotImplementedException();
        } 
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)           
        {
            if(!ModelState.IsValid) return View();

            try{
               var user = await _accountsService.CreateUserAsync(model);
                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect("~/");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }
    }
}
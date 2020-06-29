using System;
using System.Text;
using System.Threading.Tasks;
using EstateApp.Data.Entities;
using EstateApp.Web.Interfaces;
using EstateApp.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace EstateApp.Web.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly UserManager<ApplicationUser> _userManger;
        public AccountsService(
            UserManager<ApplicationUser> userManager)
        {
            _userManger = userManager;
        }

        public async Task<ApplicationUser> CreateUserAsync(RegisterModel model)
        {
            if(model is null) throw new ArgumentNullException
            (message: "invalid details provided", null);

            var user = new ApplicationUser
            {
                UserName = model.email,
                Email = model.email,
                FullName = model.fullname,
            };

            var result = await _userManger.CreateAsync(user, model.password);
            if(!result.Succeeded)
            {
                throw new InvalidOperationException(message:  AddErrors(result), null);
            }
            return user;
        }
        private string AddErrors(IdentityResult result)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var error in result.Errors)
            {
                sb.Append(error.Description + " ");
            }
            return sb.ToString();
        }
    }
}
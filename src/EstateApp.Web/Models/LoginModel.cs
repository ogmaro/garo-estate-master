using System.ComponentModel.DataAnnotations;

namespace EstateApp.Web.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string email {get; set;}
        
        [Required]
        public string password {get; set;}
    }
}
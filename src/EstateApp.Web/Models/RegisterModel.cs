using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EstateApp.Web.Models
{
    public class RegisterModel 
    {
        [DisplayName("Name")]
        [Required]
        public string fullname {get; set;}

        [DisplayName("Email Address")]
        [Required]
        [EmailAddress]
        public string email {get; set;}
        
        [DisplayName("Password")]
        [Required]
        [DataType(DataType.Password)]
        public string password {get; set;}
        [DisplayName("Confirm Password")]
        [Required]
        [Compare(nameof(password))]
        public string confirmPassword {get; set;}
    }
}
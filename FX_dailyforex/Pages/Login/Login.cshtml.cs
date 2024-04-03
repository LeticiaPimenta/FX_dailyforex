using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FX_dailyforex.Pages.Login
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Authentication Authentication { get; set; } = new Authentication();

        public void OnGet()
        {
        }
        
        public void OnPost() { }
    }

    public class Authentication
    {
        [Required]
        [Display(Name = "Client ID")]
        public string ClientId { get; set;} = string.Empty;
        [Required]
        [Display(Name = "User ID")]
        public string UserId { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

    }
}

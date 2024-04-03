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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            if (Authentication.ClientId == "012345" && Authentication.UserId == "012345" && Authentication.Password == "012345")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "John"),
                    new Claim(ClaimTypes.Email, "john@vfxfinancial.com.br")
                };

                var identity = new ClaimsIdentity(claims, "CookieAuthentication");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("CookieAuthentication", claimsPrincipal);

                return RedirectToPage("/Index");
            }
            return Page();
        }
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

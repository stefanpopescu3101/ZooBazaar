using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Class_Library.Data_Access;
using Class_Library.Object_Classes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZooBazaar_SAIA_Web.Pages
{
    public class LoginModel : PageModel
    {
        EmployeeDb db = new EmployeeDb();
        
        [BindProperty]
        [Required(ErrorMessage = "Please enter login.")]
        public string Login { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter a password.")]
        public string Password { get; set; }


        public string Message { get; set; }
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Password = Hasher.ComputeSha256Hash(Password);
                bool isVerified = db.LoginValidation(Login, Password);

                if (isVerified)
                {
                    Response.Cookies.Append("user", Login);
                    var userId = db.GetEmployeeIdByUsername(Login);
                    Response.Cookies.Append("id", userId.ToString());
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,Login)
                    };

                    var identity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                    return RedirectToPage("Index");
                }
                else
                {
                    this.Message = "Invalid credentials.";
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}

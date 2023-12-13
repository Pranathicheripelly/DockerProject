using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DockerProject.Pages
{
    
        public class LoginModel : PageModel
        {
            public IActionResult OnPost()
            {
                // Simplified logic for demonstration
                string username = Request.Form["username"];
                string password = Request.Form["password"];

                // Check if username and password are valid (example)
                if (username == "user" && password == "pass")
                {
                    // Redirect to Dashboard on successful login
                    return RedirectToPage("/Dashboard");
                }

                // Handle invalid credentials or failed login
                return Page();
            }
        }
    }


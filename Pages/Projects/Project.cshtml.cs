using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeriDeveloperWebApp.Pages.Projects
{
    public class ProjectModel : PageModel
    {
        public IActionResult OnGet(int id)
        {
            if (id != 0)
            {
                return Page();
            }
            else
            {
                string url = Url.Page("../Projects");
                return Redirect(url);
            }
        }
    }
}

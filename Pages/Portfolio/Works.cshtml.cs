using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeriDeveloperWebApp.Pages.Portfolio
{
    public class WorksModel : PageModel
    {
        public Models.Portfolio Portfolio { get; set; }
      
        public IActionResult OnGet(long category_id)
        {
            if (category_id > 0)
            {
                //Portfolio = new Model.Portfolio();
                //WorkerDB.FillPortfolioCategories(Portfolio, category_id);

                return Page();
            }
            else
            {
                string url = Url.Page("../Portfolio");
                return Redirect(url);
            }
        }
    }
}

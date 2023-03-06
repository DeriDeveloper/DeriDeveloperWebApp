using System;
using DeriDeveloperWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeriDeveloperWebApp.Pages
{
    public class PortfolioModel : PageModel
    {
        public Models.Portfolio Portfolio { get; set; }
        public void OnGet()
        {

            //Portfolio = new Models.Portfolio();
            //WorkerDB.FillPortfolioCategories(Portfolio);

            
        }
    }
}

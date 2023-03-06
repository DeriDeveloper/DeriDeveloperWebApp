using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeriDeveloperWebApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Models.Portfolio.Review> Reviews { get; set; } = new List<Models.Portfolio.Review>();
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string name)
        {
            //Reviews = WorkerDB.GetPortfolioWorksReviews();
        }

        public void OnPost(string name)
        {
            
        }

    }
}

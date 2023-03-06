using System;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static DeriDeveloperWebApp.Models.Portfolio;

namespace DeriDeveloperWebApp.Pages.Portfolio
{
    public class WorkModel : PageModel
    {
        public Models.Portfolio.Work Work { get; set; }
        public string ReviewsCreateToken { get; set; }
        public string OnGet(long id, string token)
        {
            return "";
            /*
            if (id > 0)
            {

                //Work = WorkerDB.GetPortfolioWorkById(id);

                if (Work != null)
                {
                    //WorkerDB.AddViewForWorkByWorkId(id);


                    if (!string.IsNullOrEmpty(token))
                    {
                        ReviewsCreateToken = token;
                    }


                    return Page();
                }
                else
                {
                    string url = Url.Page("../Portfolio");
                    return Redirect(url);
                }
            }
            else
            {
                string url = Url.Page("../Portfolio");
                return Redirect(url);
            }*/
        }

        public IActionResult OnPostReviewPublic(string name, string description, string work_id, string estimation, string token)
        {
            /*
            try
            {
                name = name.Trim();
                description = description.Trim();
                token = token.Trim();
                long workID = long.Parse(work_id.Trim());
                int estimationNum = int.Parse(estimation.Trim());



                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description) && workID > 0 && estimationNum > 0 && estimationNum <= 5 && !string.IsNullOrEmpty(token) && WorkerDB.DoesTokenForCreatingReviewMatch(workID, token))
                {
                    //WorkerDB.AddNewReviewToWorkById(workID, name, description, estimationNum);
                    //WorkerDB.UpdateReviewStatus(workID, true);
                }
                string url = HttpContext.Request.Path + "?id=" + workID;

                return Redirect(url);
            }
            catch(Exception error)
            {
                string url = Url.Page("../Portfolio");
                return Redirect(url);
            }
            */
            return null;
        }
    }
}

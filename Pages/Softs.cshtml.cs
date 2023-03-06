using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeriDeveloperWebApp.Pages
{
    public class SoftsModel : PageModel
    {
        public int PageStatusCode { get; set; }

        public int NumberPage { get; set; } = 1;
        public void OnGet(string number_page)
        {
            

            if (!string.IsNullOrEmpty(number_page))
            {
                if (DeriLibrary.Check.IsNumber(number_page, DeriLibrary.Check.TypeNumbers.Int32))
                {
                    int numPage = int.Parse(number_page);
                    if (numPage > 0)
                    {
                        NumberPage = numPage;
                    }
                    else NumberPage = 1;
                }
                else NumberPage = 1;
            }
            else NumberPage = 1;


            //PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(SoftsCount) / QuantityPerPage));
        }


        public void OnPost(string name)
        {

        }


        public static Models.Soft[]? GetSofts(int numberPage)
        {
            if (numberPage>0)
            {
                return Services.Background.Worker.GetSofts(numberPage);
            }
            return null; 
        }
    }
}

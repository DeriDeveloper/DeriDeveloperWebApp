using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DeriDeveloperWebApp.Pages
{
    public class ProjectsModel : PageModel
    {
        private readonly ILogger<ProjectsModel> _logger;

        public List<DeriDeveloperWebApp.Models.Project> Projects { get; set; } = new List<Models.Project>();


        public ProjectsModel(ILogger<ProjectsModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {

            for (int i = 1; i < 5; i++)
            {
                Projects.Add(new Models.Project()
                {
                    ID = i,
                    Name = $"Name-------------------------------------------{i}",
                    Description = $"Description-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------{i}",
                    ImagesPriview = new List<Models.Image>()
                     {
                         new Models.Image()
                         {
                              Path = DeriLibrary.WorkerImages.GetPathImage("123.png")
                         }
                     }
                });
            }
        }
    }
}

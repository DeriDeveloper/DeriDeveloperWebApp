
using DeriDeveloperWebApp.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DeriDeveloperWebApp.Pages
{
    public class CourseCertificatesModel : PageModel
    {
        public List<CourseCertificate> CourseCertificates { get; set; }

        public void OnGet()
        {
            //CourseCertificates = WorkerDB.GetMyCertificates();

            foreach(var courseCertificate in CourseCertificates)
            {
                courseCertificate.Path = DeriLibrary.WorkerImages.GetPathImage(DeriDeveloperWebApp.Config.PathToCourseCertificates + $"\\{courseCertificate.Path}", DeriLibrary.Config.FolderPhotoRoot);

                
            }
        }
    }
}

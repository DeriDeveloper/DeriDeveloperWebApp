using DeriDeveloperWebApp.Models;
using Microsoft.AspNetCore.Hosting;
using System.Text;

namespace DeriDeveloperWebApp.Services.Background
{
    public class Worker
    {
        public static IWebHostEnvironment WebHostEnvironment { get; internal set; }

        public static string GetFolderResorces()
        {
            return WebHostEnvironment.WebRootPath;
        }

        public static Soft[]? GetSofts(int numberPage)
        {
            return Services.DataBase.Worker.GetSofts(skipQuantity: (numberPage-1) * DataBase.Config.CountSoftsToReturn);
        }

        public static string GetProjectContainerHtml(string title, string description, string urlImage, string link)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<div class=\"project-main-container\">");

            sb.AppendLine($"<h3>{title}</h3>");
            //sb.AppendLine($"<p>{description}</p>");
            sb.AppendLine($"<a href=\"{link}\" target=\"_blank\" style=\"color:#4690FF;\">Перейти</a>");

            sb.AppendLine("</div>");


            return sb.ToString();
        }
    }
}

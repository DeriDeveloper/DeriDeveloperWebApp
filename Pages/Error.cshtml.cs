using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DeriDeveloperWebApp.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        public string RequestId { get; set; }
        public int PageStatusCode { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            PageStatusCode = HttpContext.Response.StatusCode;

            string errorMessage = $"Статус страницы: {PageStatusCode}";
            DeriLibrary.Console.Worker.NotifyErrorMessageCall(errorMessage: errorMessage);
            
            //_logger.Log(LogLevel.Error, errorMessage);

            //_logger.Log(LogLevel.Error, "ошибка в error");
        }

    }
}

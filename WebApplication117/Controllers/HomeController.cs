using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication117.Models;
using TXTextControl.Web.MVC.DocumentViewer.Models;

namespace WebApplication117.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult HandleSignature([FromBody] SignatureData data, string securityToken)
        {
            ReturnObject returnObject = new ReturnObject();
            
            if (securityToken != "123")
            {
                return Ok(returnObject);
            }
                
            // here, you have access to the signed document and other meta data
            var test = data.SignedDocument.Document; 

            returnObject.Success = true;
            returnObject.Id = data.SignedDocument.UniqueId;

            return Ok(returnObject);
        }

        public class ReturnObject
        {
            public string Id { get; set; }
            public bool Success { get; set; } = false;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
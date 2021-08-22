using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hahn.ApplicatonProcess.July2021.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}

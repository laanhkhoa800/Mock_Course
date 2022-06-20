using Microsoft.AspNetCore.Mvc;

namespace FA.LegalHCM.Web.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

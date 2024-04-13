using Microsoft.AspNetCore.Mvc;

namespace GlobalManagment.Controllers
{
    public class AllInOneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Jandag.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GlobalManagment.Controllers
{
    public class EnginerController : Controller
    {
        public IActionResult Index()
        {

            DutyEnginerModel dut = new DutyEnginerModel()
            {
                OptionList = new List<SelectListItem>()
                { new SelectListItem(){Text="monishne",Value="kaiaa"},
                new SelectListItem(){Text="rame",Value="rume"},
                new SelectListItem(){Text="rame",Value="sadme"},
                new SelectListItem(){Text="vinme",Value="sadgac"}
                }
            };
            return View(dut);
        }

        [HttpPost]
        public IActionResult Insert(string choice)
        {
            throw new Exception("edxzaxis");
        }
    }
}

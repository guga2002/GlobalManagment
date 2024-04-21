using Jandag.BLL.Models;
using Jandag.BLL.Models.ViewModels;
using Jandag.Persistance.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagment.Controllers
{
    public class ChanellAlarmController : Controller
    {
        private readonly IService ser;

        public ChanellAlarmController(IService se)
        {
                this.ser = se;
        }
        public async Task<IActionResult> Index()
        {
            UniteChanellNamesAndAlarms data = new UniteChanellNamesAndAlarms()
            {
                namees = await ser.GetChanellNames(),
                ports = await ser.GetPortsWhereAlarmsIsOn()
            };
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> HandleButtonClick(string buttonId)
        {
            if(buttonId is null)
            {
                return RedirectToAction("Index");
            }
            AllInOneModel mod = new AllInOneModel()
            {
                DesclamlerInfo = "rame",
                ChanellFormat = "vinme",
                ChanellName= buttonId
            };

            return View(mod);
        }
    }
}

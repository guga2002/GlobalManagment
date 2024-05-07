using DDL.Database_Layer.Entities;
using Jandag.BLL.Interface;
using Jandag.BLL.Models;
using Jandag.BLL.Models.ViewModels;
using Jandag.Persistance.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagment.Controllers
{
    public class UniteController : Controller
    {
        private readonly ISatteliteFrequencyService ser;
        private readonly IService chanells;
        private readonly IService seq;

        public UniteController(ISatteliteFrequencyService ser, IService chanells, IService seq)
        {
            this.ser = ser;
            this.chanells = chanells;
            this.seq = seq;

        }
        public async Task<IActionResult> Index()
        {
            var res = await ser.GetMonitoringFrequencies();
            var ports = await chanells.GetPortsWhereAlarmsIsOn();
            foreach (var item in res)
            {
                foreach (var it in item.details)
                {
                    if (ports.Contains(it.PortIn250))
                    {
                        it.HaveError = true;
                    }
                    else
                    {
                        it.HaveError = false;
                    }

                }
            }
            UniteModel mod = new UniteModel();
            mod.satelliteview = res;
            UniteChanellNamesAndAlarms data = new UniteChanellNamesAndAlarms()
            {
                namees = await seq.GetChanellNames(),
                ports = await seq.GetPortsWhereAlarmsIsOn()
            };
            mod.chyanellnameandalarm = data;
            return View(mod);
        }
    }
}

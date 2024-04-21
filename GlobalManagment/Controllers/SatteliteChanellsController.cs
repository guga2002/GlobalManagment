using Jandag.BLL.Interface;
using Jandag.BLL.Models;
using Jandag.BLL.Models.ViewModels;
using Jandag.Persistance.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GlobalManagment.Controllers
{
    public class SatteliteChanellsController : Controller
    {
        private readonly ISatteliteFrequencyService ser;
        private readonly IService chanells;
        public SatteliteChanellsController(ISatteliteFrequencyService se, IService chanells)
        {
            this.ser = se;
            this.chanells = chanells;
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
            return View(res);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post(SatteliteFrequencyModel mod)
        {
            try
            {
                var res = await ser.AddAsync(mod);
                if (res)
                {
                    return RedirectToAction("Details");
                }

                throw new ArgumentException("Gaxaria");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> Details()
        {
            List<FrequencyDeleteModel> mod = new List<FrequencyDeleteModel>();
            var res = await ser.GetAllAsync();
            foreach (var item in res)
            {
                mod.Add(new FrequencyDeleteModel()
                {
                    Degree = item.Degree,
                    Frequency = item.Frequency,
                    Polarization = item.Polarisation,
                    SymbolRate = item.SymbolRate,
                    PortIn250 = item.PortIn250,
                });
            }
            return View(mod);
        }

        [HttpPost]
        public IActionResult Edit(FrequencyDeleteModel mod)
        {
            throw new ArgumentException("varedaqtireb");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(FrequencyDeleteModel mod)
        {
            await ser.Delete(mod.PortIn250);
            return RedirectToAction("Details");
        }

        [HttpGet]
        public async Task<IActionResult> ViewAdditionalDetails(int frequency)
        {
            var mod = await ser.GetDetailsByEmrport(frequency);
            return View(mod);
        }
    }
}

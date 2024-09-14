using DDL.Database_Layer.Entities;
using Jandag.BLL.Interface;
using Jandag.BLL.Models;
using Jandag.BLL.Models.ViewModels;
using Jandag.Persistance.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GlobalManagment.Controllers
{
    public class UniteController : Controller
    {
        private readonly ISatteliteFrequencyService ser;
        private readonly IService chanells;
        private readonly IService seq;
        private readonly ITemperatureService temperature;

        public UniteController(ISatteliteFrequencyService ser, IService chanells, IService seq, ITemperatureService temperature)
        {
            this.ser = ser;
            this.chanells = chanells;
            this.seq = seq;
            this.temperature = temperature;
        }

        public async Task<IActionResult> getRegionInfo()
        {
            int port = 183;
            UdpClient client = new UdpClient(port);

            try
            {
                while (true)
                { 
                    IPEndPoint clientendpoi=new IPEndPoint(IPAddress.Any, 0);
                    var recievedinfo = client.Receive(ref clientendpoi);

                    string message = Encoding.UTF8.GetString(recievedinfo);
                    return Ok(message);
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp);
                Console.WriteLine("shecdomaa"  );
            }

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
            var result= await temperature.GetCUrrentTemperature();
            mod.temperature = result.Item1;
            mod.Humidity=result.Item2;
            return View(mod);
        }
    }
}

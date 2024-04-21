using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Jandag.BLL.Interface;
using Jandag.Persistance.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllInOneService ser;
        private readonly IChanellServices chanellser;
        private readonly IService names;
        public HomeController(IAllInOneService ser, IChanellServices chanellser, IService names)
        {
            this.ser = ser;
            this.chanellser = chanellser;
            this.names = names;
        }
        public async Task<IActionResult> Index()
        {
            var res = await names.GetChanellNames();
            foreach (var item in res)
            {
                await chanellser.AddAsync(new Jandag.BLL.Models.ChanellModel()
                {
                    Name = item.Value
                });
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
        [HttpGet]
        public async Task<object> Get(DataSourceLoadOptions loadOptions)
        {
            var res = await ser.SeedData();
            return DataSourceLoader.Load(res, loadOptions);
        }
    }
}

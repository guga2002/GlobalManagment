using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Jandag.BLL.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllInOneService ser;
        public HomeController(IAllInOneService ser)
        {
            this.ser = ser;
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
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

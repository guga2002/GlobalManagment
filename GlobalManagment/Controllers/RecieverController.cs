using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Jandag.BLL.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagment.Controllers
{
    [Authorize]
    public class RecieverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<object> Get(DataSourceLoadOptions loadOptions)
        {

            List<RecieverViewModel> mod = new List<RecieverViewModel>();
            return DataSourceLoader.Load(mod, loadOptions);
        }

        [HttpPost]
        public IActionResult insert(RecieverViewModel mod)
        {
            return Ok();
        }
    }
}

using Jandag.BLL.Interface;
using Jandag.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace GlobalManagment.Controllers
{
    public class SourceController : Controller
    {
        private readonly IsourceServices ser;
        public SourceController(IsourceServices ser)
        {
            this.ser = ser;
        }
        public async Task<IActionResult> Index()
        {
            var res=await ser.GetAllAsync();
            return View(res);
        }

        public  IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(SourceModel mod)
        {
           var res=await ser.AddAsync(mod);
            if(res)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
           var res=await ser.Delete(id);
            if(res)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Add");
        }
    }
}

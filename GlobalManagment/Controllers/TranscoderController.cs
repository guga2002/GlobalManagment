using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Jandag.BLL.Interface;
using Jandag.BLL.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagment.Controllers
{
    public class TranscoderController : Controller
    {
        private readonly ITranscoderService ser;

        public TranscoderController(ITranscoderService se)
        {
            this.ser = se; 
        }
        public async Task< IActionResult> Index()
        {
            var mod = await ser.GetAllAsync();
            return View(mod);
        }

        [HttpPut]
        public IActionResult Update(TranscoderViewModel mod)
        {
            throw new ArgumentException("gaajvii");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Insert(TranscoderViewModel mod)
        {

            try
            {

                var res = await ser.AddAsync(mod);
                if (res)
                {
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "modeltate kia validuri";
                return RedirectToAction("Add");
            }
            catch (Exception exp)
            {
                return RedirectToAction("Add");

                TempData["Error"] = exp.Message;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await ser.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}

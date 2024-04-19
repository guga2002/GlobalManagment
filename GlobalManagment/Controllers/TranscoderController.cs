using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Jandag.BLL.Interface;
using Jandag.BLL.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            throw new ArgumentException("Go away  from me");
        }

        public async Task<IActionResult> Add()
        {
            var res = await ser.GetDropDownList();
            return View(res);
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
                TempData["Error"] = exp.Message;
                return RedirectToAction("Add");
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

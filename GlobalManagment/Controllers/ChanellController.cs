using Jandag.BLL.Interface;
using Jandag.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagment.Controllers
{
    public class ChanellController : Controller
    {
        private readonly IChanellServices ser;
        public ChanellController(IChanellServices se)
        {
            this.ser = se;
                
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var res = await ser.GetAllAsync();
                return View(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string Name)
        {
            if(Name  is not null)
            {
               var res= await ser.DeleteByName(Name);
                if(res)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            throw new ArgumentException("shecoma");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Insert(string Name)
        {
            try
            {

                var res = await ser.AddAsync(new ChanellModel()
                {
                    Name = Name,
                });
                if (res)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Add");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

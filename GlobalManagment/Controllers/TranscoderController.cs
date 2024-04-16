using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Jandag.BLL.Interface;
using Jandag.BLL.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagment.Controllers
{
    [Authorize]
    public class TranscoderController : Controller
    {
        private readonly ITranscoderService ser;

        public TranscoderController(ITranscoderService se)
        {
            this.ser = se; 
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<object> Get(DataSourceLoadOptions loadOptions)
        {
            List<TranscoderViewModel> mod = new List<TranscoderViewModel>()
            {
                new TranscoderViewModel()
                {
                    Id=2,
                    Card="fdffg",
                    CHanellName="Guga",
                    EmrNumber=200,Port="Rrt",
                    TransocdingFormat=TransocdingFormat.Mpeg2
                },
                  new TranscoderViewModel()
                {
                      Id=3,
                    Card="fdffg",
                    CHanellName="Guga",
                    EmrNumber=200,Port="Rrt",
                    TransocdingFormat=TransocdingFormat.HD
                },
                    new TranscoderViewModel()
                {
                        Id=4,
                    Card="fdffg",
                    CHanellName="Guga",
                    EmrNumber=100,Port="Rrt",
                    TransocdingFormat=TransocdingFormat.Sd
                },
                      new TranscoderViewModel()
                {
                    Card="fdffg",
                    CHanellName="Guga",
                    EmrNumber=120,Port="Rrt",
                    TransocdingFormat=TransocdingFormat.HD
                }
              
            };
            return DataSourceLoader.Load(mod, loadOptions);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            throw new ArgumentException("Fuck you");
        }

        [HttpPut]
        public IActionResult Update(TranscoderViewModel mod)
        {
            throw new ArgumentException("gaajvii");
        }

        [HttpPost]
        public async Task<IActionResult>Insert(TranscoderViewModel mod)
        {
            try
            {
                await ser.AddAsync(mod);
            }
            catch (Exception exp)
            {
                TempData["Error"] = exp.Message;
            }
     
            return RedirectToAction("Index");
        }
    }
}

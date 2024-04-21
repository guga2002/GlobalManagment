using AutoMapper;
using Jandag.BLL.Interface;
using Jandag.BLL.Models;
using Jandag.DLL.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Jandag.BLL.Services
{
    public class SourceService : AbstractService, IsourceServices
    {
        public SourceService(IMapper map, IUniteOfWork wor) : base(map, wor)
        {
        }

        public async Task<bool> AddAsync(SourceModel item)
        {
            try
            {
                var channel = await work.ChanellRepository.GetById(item.ChanellId);

                if (channel == null)
                {
                    throw new ArgumentException("Arxi ar aris");
                    //return false;
                }
                var satellite = await work.satteliterFrequencyRepository.GetByIdIds(item.Reciever_ID ?? 100);
                var source = new DLL.Entities.Source()
                {
                    ChanellFormat = item.ChanellFormat,
                    Status = true,
                   sourceName=item.sourceName,
                   card=item.card,
                   EmrNumber=int.Parse(item.EMR),
                   port=item.port,
                    ChanellId=item.ChanellId,
                };

                if (satellite != null)
                {
                    source.SatteliteId = item.Reciever_ID;
                }
                await work.sourceRepository.Add(source);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }


        public async Task<bool> Delete(int id)
        {
            try
            {
               await work.sourceRepository.Remove(id);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<SourceModel>> GetAllAsync()
        {
            List<SourceModel> mod = new List<SourceModel>();
            var res= await work.sourceRepository.GetAll();
            foreach (var item in res)
            {
                var mok = new SourceModel
                {
                    ChanellFormat = item.ChanellFormat,
                    Status = item.Status,
                    Reciever_ID = item.SatteliteId,
                    ChanellId = item.ChanellId,
                    Id=item.Id,
                };
                mod.Add(mok);
            }
            return mod;
        }

        public Task<bool> UpdateAsync(SourceModel item)
        {
            throw new NotImplementedException();
        }

        public async Task<SourceModel> GetDropDOwnListData()
        {
            var sour = new SourceModel()
            { ChanellFormat="Undefined"};

            sour.StatusList = new List<SelectListItem>()
            {
                new SelectListItem("აქტიური","1"),
                new SelectListItem("რეზერვი","0")
            };
            sour.CHanellFormatList = new List<SelectListItem>()
            {
                new SelectListItem("MPEG2 SD","MPEG2 SD"),
                  new SelectListItem("MPEG4 SD","MPEG4 SD"),
                  new SelectListItem("MPEG4 HD","MPEG4 HD")
            };
            var chanells=await work.ChanellRepository.GetAll();
            sour.ChanellList = new List<SelectListItem>();
            foreach (var item in chanells)
            {
                sour.ChanellList.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                });
            }
            sour.RecieverList = new List<SelectListItem>();
            var recieve=await work.satteliterFrequencyRepository.GetAll();
            foreach (var item in recieve)
            {
                sour.RecieverList.Add(new SelectListItem()
                {
                    Text = $"{item.Degree}-{item.Frequency} {item.Polarisation} {item.SymbolRate}",
                    Value = item.Id.ToString(),
                }) ;
            }
            return sour;
        }
    }
}

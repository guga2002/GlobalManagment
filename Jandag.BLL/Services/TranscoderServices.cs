using AutoMapper;
using DDL.Database_Layer.Entities;
using Jandag.BLL.Interface;
using Jandag.BLL.Models.ViewModels;
using Jandag.DLL.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Jandag.BLL.Services
{
    public class TranscoderServices : AbstractService, ITranscoderService
    {
        public TranscoderServices(IMapper map, IUniteOfWork wor) : base(map, wor)
        {
        }

        public async Task<bool> AddAsync(TranscoderViewModel Item)
        {
            
            var source = await work.sourceRepository.GetById(int.Parse(Item.Id));
            if (source !=null)
            {
                    source.ChanellFormat = Item.TranscodingFormat;
                    Transcoder trans = new Transcoder()
                    {
                        Port = int.Parse(Item.Port),
                        Card = int.Parse(Item.Card),
                        EmrNumber =int.Parse(Item.EmrNumber),
                        Source_ID=source.Id,
                         Source=source,
                    };
                    await work.transcoderRepository.Add(trans);
                    return true;
            }
            throw new ArgumentException("msgavsi arxi ar arsebobs");
        }


        public async Task<TranscoderViewModel> GetDropDownList()
        {
            TranscoderViewModel vw = new TranscoderViewModel();

            var res = await work.sourceRepository.GetAll();
            vw.CHanellNameList = new List<SelectListItem>();
            foreach (var item in res)
            {
                vw.CHanellNameList.Add(new SelectListItem()
                {
                    Text = $"{item.chanell.Name}-{item.ChanellFormat}",
                    Value = item.Id.ToString(),
                });
            }
            vw.TranscodingFormatList = new List<SelectListItem>();
            vw.TranscodingFormatList.Add(new SelectListItem()
            {
                Text = "MPEG4-HD",
                Value = "MPEG4-HD"
            });
            vw.TranscodingFormatList.Add(new SelectListItem()
            {
                Text = "MPEG4-SD",
                Value = "MPEG4-SD"
            });
            vw.TranscodingFormatList.Add(new SelectListItem()
            {
                Text = "MPEG2-SD",
                Value = "MPEG2-SD"
            });
            vw.EmrNumberList = new List<SelectListItem>()
            { new SelectListItem()
               {
                Text="ასი",
                Value="100"
               },
                new SelectListItem()
               {
                Text="ასათი",
                Value="110"
               },
                 new SelectListItem()
               {
                Text="ასოცი",
                Value="120"
               },
                   new SelectListItem()
               {
                Text="ასოცდაათი",
                Value="130"
               },
                     new SelectListItem()
               {
                Text="ორასი",
                Value="200"
               },
                           new SelectListItem()
               {
                Text="ორასოცდაათი",
                Value="230"
               },
            };
            return vw;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                await work.transcoderRepository.Remove(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<TranscoderViewModel>> GetAllAsync()
        {
            try
            {
                List<TranscoderViewModel> view = new List<TranscoderViewModel>();
                var trans = await work.transcoderRepository.GetAll();
                foreach (var item in trans)
                {
                    var nk = new TranscoderViewModel()
                    {
                        Card = item.Card.ToString(),
                        Port = item.Port.ToString(),
                        EmrNumber = item.EmrNumber.ToString(),
                        TranscodingFormat = item.Source.ChanellFormat,
                        Id = item.Source.chanell.Name,
                    };
                    view.Add(nk);
                }
                return view;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Remove(int emrNumber, int card, int port)
        {
            try
            {
                await work.transcoderRepository.Remove(emrNumber, card, port);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> UpdateAsync(TranscoderViewModel item)
        {
            throw new NotImplementedException();
        }
    }
}

using AutoMapper;
using Jandag.BLL.Interface;
using Jandag.BLL.Models;
using Jandag.DLL.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Services
{
    public class AllInOneService : AbstractService, IAllInOneService
    {
        public AllInOneService(IMapper map, IUniteOfWork wor) : base(map, wor)
        {
        }

        public async Task<List<AllInOneModel>> SeedData()
        {
            List<AllInOneModel> model=new List<AllInOneModel>();
            var source =await work.sourceRepository.GetAll();
            foreach (var item in source)
            {
                var mod=new AllInOneModel();
                mod.SourceIsActive = item.Status;
                mod.ChanellFormat = item.ChanellFormat;
             
                if(item.Transcoder is not null)
                {
                    mod.TranscoderInfo = $"EMR:{item.Transcoder.EmrNumber} ->Card:{item.Transcoder.Card} ->Port:{item.Transcoder.Port}";
                }
                else
                {
                    mod.TranscoderInfo = "Undefined";
                }
                if(item.chanell is not null)
                {
                    mod.ChanellName = item.chanell.Name;
                }
                else
                {
                    mod.ChanellName = "Undefined";
                }
                if(item.Desclambler is not null)
                {
                    mod.DesclamlerInfo = $"EMR:{item.Desclambler.EmrNumber} -> Card:{item.Desclambler.Card} -> Port:{item.Desclambler.Port}";
                }
                else
                {
                    mod.DesclamlerInfo = "Undefined";
                }
                if(item.Reciever is not null)
                {
                    mod.RecieverInfo = $"EMR:{item.Reciever.EmrNumber} -> Card:{item.Reciever.Card} -> Port:{item.Reciever.Port}";
                    mod.Frequency=item.Reciever.Frequency;
                }
                else
                {
                    mod.RecieverInfo = "Undefined";
                }
               model.Add(mod);
            }

            return model;
        }
    }
}

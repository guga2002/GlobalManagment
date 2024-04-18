using AutoMapper;
using DDL.Database_Layer.Entities;
using Jandag.BLL.Interface;
using Jandag.BLL.Models.ViewModels;
using Jandag.DLL.Interfaces;

namespace Jandag.BLL.Services
{
    public class TranscoderServices : AbstractService, ITranscoderService
    {
        public TranscoderServices(IMapper map, IUniteOfWork wor) : base(map, wor)
        {
        }

        public async Task<bool> AddAsync(TranscoderViewModel Item)
        {
            
            var source = await work.sourceRepository.GetById(Item.Id);
            if (source !=null)
            {
                    source.ChanellFormat = Item.TransocdingFormat;
                    Transcoder trans = new Transcoder()
                    {
                        Port = int.Parse(Item.Port),
                        Card = int.Parse(Item.Card),
                        EmrNumber = Item.EmrNumber,
                        Source_ID=source.Id,
                         Source=source,
                    };
                    await work.transcoderRepository.Add(trans);
                    return true;
            }
            throw new ArgumentException("msgavsi arxi ar arsebobs");
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
                        EmrNumber = item.EmrNumber,
                        TransocdingFormat = item.Source.ChanellFormat,
                        CHanellName = item.Source.chanell.Name,
                        Id=item.Id,
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

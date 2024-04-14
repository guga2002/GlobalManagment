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
            var source = await work.sourceRepository.GetBychanellName(Item.CHanellName);
            if (source is not null)
            {
                int id = -1;
                if (source.chanell is not null)
                {
                    id = source.chanell.Id;
                }

                if (id != -1)
                {
                    Transcoder trans = new Transcoder()
                    {
                        Port = Item.Id,
                        Card = Item.Id,
                        EmrNumber = Item.EmrNumber,
                        Source_ID = id,
                    };
                    await work.transcoderRepository.Add(trans);
                    await work.CommitAndSavechanges();
                    return true;
                }
            }
            throw new ArgumentException("msgavsi arxi ar arsebobs");
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TranscoderViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TranscoderViewModel item)
        {
            throw new NotImplementedException();
        }
    }
}

﻿using AutoMapper;
using Jandag.BLL.Interface;
using Jandag.BLL.Models;
using Jandag.DLL.Interfaces;

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
                    throw new ArgumentException("Channel does not exist");
                }
                var satellite = await work.satteliterFrequencyRepository.GetByIdIds(item.Reciever_ID ?? 100);
                var source = new DLL.Entities.Source()
                {
                    ChanellFormat = item.ChanellFormat,
                    Status = true,
                   // chanell = channel,
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
    }
}
using AutoMapper;
using DDL.Database_Layer.Entities;
using Interfaces;
using Jandag.BLL.Interface;
using Jandag.BLL.Models;
using Jandag.DLL.Entities;
using Jandag.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Services
{
    public class ChanellServices : AbstractService, IChanellServices
    {
        public ChanellServices(IMapper map, IUniteOfWork wor) : base(map, wor)
        {
        }

        public async Task<bool> AddAsync(ChanellModel Item)
        {
            try
            {
                await work.ChanellRepository.Add(new Chanell()
                {
                    Name = Item.Name,
                });
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteByName(string Name)
        {
            try
            {
                await work.ChanellRepository.Remove(Name);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ChanellModel>> GetAllAsync()
        {
            var res=await work.ChanellRepository.GetAll();
            List<ChanellModel> mod = new List<ChanellModel>();
            foreach (var item in res)
            {
                var chanell = new ChanellModel()
                {
                    Name = item.Name,
                    ID=item.Id,
                };
                foreach (var it in item.Sources)
                {
                    chanell.Sources.Add(new SourceModel()
                    {ChanellFormat=it.ChanellFormat,
                    Status=it.Status,
                    });
                }
                mod.Add(chanell);
            }
            return mod;
        }

        public Task<bool> UpdateAsync(ChanellModel item)
        {
            throw new NotImplementedException();
        }
    }
}

using DDL.Database_Layer.Entities;
using Jandag.DLL.Data;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Speaker.leison.Database_Layer.Interfaces;
using System;
using System.Linq;

namespace Speaker.leison.Database_Layer.Repositories
{
    public class RecieverRepository : BaseRepository, IRecieverInterface
    {
        private readonly DbSet<Reciever> _recievers;
        public RecieverRepository(GlobalTvDb db):base(db)
        {
                _recievers=database.Set<Reciever>();
        }

        public async Task Add(Reciever item)
        {
            if (!await _recievers.AnyAsync(io => io.Frequency == item.Frequency))
            {
                await _recievers.AddAsync(item);
                await database.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Reciever>> GetAll()
        {
            return await _recievers.AsNoTracking().ToListAsync();
        }

        public async Task<Reciever> GetById(int id)
        {
            var res= await _recievers.FirstOrDefaultAsync(io=>io.Id== id);
            if(res is null)
            {
                return null;
            }
            return res;
        }

        public async Task Remove(int id)
        {
            var res = await _recievers.FirstOrDefaultAsync(io => io.Id == id);
            if(res is not null)
            {
                _recievers.Remove(res);
                await database.SaveChangesAsync();
            }
        }

        public async Task Update(Reciever item)
        {
            var res = await _recievers.FirstOrDefaultAsync(io => io.Id == item.Id);
            if(res is not null)
            {
                _recievers.Entry(res).CurrentValues.SetValues(item);
                await database.SaveChangesAsync();
            }
        }
    }
}

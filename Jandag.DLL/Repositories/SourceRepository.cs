using Jandag.DLL.Data;
using Jandag.DLL.Entities;
using Jandag.DLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.DLL.Repositories
{
    public class SourceRepository : BaseRepository, ISourceRepository
    {
        private readonly DbSet<Source> source;
        public SourceRepository(GlobalTvDb database) : base(database)
        {
            source=database.Set<Source>();
        }

        public async Task Add(Source item)
        {
            if (!await source.AnyAsync(io => io.Id==item.Id))
            {
                await source.AddAsync(item);
                await database.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Source>> GetAll()
        {
           return await source.Include(io=>io.Transcoder).Include(io=>io.Desclambler).Include(io=>io.Reciever).Include(io=>io.chanell).ToListAsync();
        }

        public async Task<Source> GetById(int id)
        {
            var res= await source.FirstOrDefaultAsync(io=>io.Id==id);
            if(res is not null)
            {
                return res;
            }
            return null;
        }

        public async Task Remove(int id)
        {
            var res = await source.FirstOrDefaultAsync(io => io.Id == id);
            if(res is not null)
            {
                source.Remove(res);
                await database.SaveChangesAsync(true);
            }
        }

        public async Task Update(Source item)
        {
            var res = await source.FirstOrDefaultAsync(io => io.Id == item.Id);
            if (res is not null)
            {
                source.Entry(res).CurrentValues.SetValues(item);
                await database.SaveChangesAsync();
            }
        }

    }
}

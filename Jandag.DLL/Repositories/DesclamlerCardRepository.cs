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
    public class DesclamlerCardRepository : BaseRepository, IDesclamlerCard
    {
        private readonly DbSet<DesclamlerCard> cards;
        public DesclamlerCardRepository(GlobalTvDb database) : base(database)
        {
            cards=database.Set<DesclamlerCard>();
        }

        public async Task Add(DesclamlerCard item)
        {
          if(!await cards.AnyAsync(io=>io.DesclamblerId==item.DesclamblerId))
            {
                await cards.AddAsync(item);
                await database.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DesclamlerCard>> GetAll()
        {
            return await cards.AsNoTracking().ToListAsync();
        }

        public async Task<DesclamlerCard> GetById(int id)
        {
            var res=await cards.FirstOrDefaultAsync(io => io.Id == id);
            if(res is not null)
            {
                return res;
            }
            return res;
        }

        public async Task Remove(int id)
        {
            var res = await cards.FirstOrDefaultAsync(io => io.Id == id);
            if (res is not null)
            {
                cards.Remove(res);
                await database.SaveChangesAsync();
            }
        }

        public async Task Update(DesclamlerCard item)
        {
            var res = await cards.FirstOrDefaultAsync(io => io.DesclamblerId == item.DesclamblerId);
            if (res is not null)
            {
                cards.Entry(res).CurrentValues.SetValues(item);
                await database.SaveChangesAsync(true);
            }
        }
    }
}

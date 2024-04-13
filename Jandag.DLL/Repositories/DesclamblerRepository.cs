using DDL.Database_Layer.Entities;
using Interfaces;
using Jandag.DLL.Data;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Speaker.leison.Database_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speaker.leison.Database_Layer.Repositories
{
    public class DesclamblerRepository : BaseRepository, IDesclambler
    {
        private readonly DbSet<Desclambler> desclamblers;
        public DesclamblerRepository(GlobalTvDb db):base(db)
        {
            desclamblers = database.Set<Desclambler>(); 
        }

        public async Task Add(Desclambler item)
        {
            if (!await desclamblers.AnyAsync(io => io.Source_ID == item.Source_ID))
            {
               await desclamblers.AddAsync(item);
               await  database.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Desclambler>> GetAll()
        {
            return await desclamblers
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<Desclambler?> GetById(int id)
        {
           return desclamblers.AsNoTracking().
                FirstOrDefaultAsync(desclamblers => desclamblers.Id == id);
        }

        public async Task Remove(int id)
        {
            var desc = await desclamblers.AsNoTracking().
                FirstOrDefaultAsync(desclamblers => desclamblers.Id == id);
            if(desc is not null)
            {
                desclamblers.Remove(desc);
            }
        }

        public async Task Update(Desclambler item)
        {
            var desc = await desclamblers.AsNoTracking().
                 FirstOrDefaultAsync(desclamblers => desclamblers.Source_ID == item.Source_ID);
            if(desc != null)
            {
                desclamblers.Entry(desc).CurrentValues.SetValues(item);
                await database.SaveChangesAsync();
            }
        }
    }
}

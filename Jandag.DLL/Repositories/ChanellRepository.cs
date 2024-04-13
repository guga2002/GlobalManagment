using DDL.Database_Layer.Entities;
using Interfaces;
using Jandag.DLL.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Repositories
{
    public class ChanellRepository : BaseRepository,IChanellRepository
    {
        private readonly DbSet<Chanell> chanells;

        public ChanellRepository(GlobalTvDb db) : base(db)
        {
            chanells = this.database.Set<Chanell>();
        }

        public async Task Add(Chanell item)
        {
            if(! await chanells.AnyAsync(IO=>IO.Name == item.Name))
            {
               await chanells.AddAsync(item);
            }
        }

        public async Task<IEnumerable<Chanell>> GetAll()
        {
          return await chanells.AsNoTracking().ToListAsync();
        }

        public async Task<Chanell?> GetById(int id)
        {
            return await chanells.AsNoTracking().FirstOrDefaultAsync(io => io.Id == id);
        }

        public async Task Remove(  int id)
        {
           var chan=await chanells.FirstOrDefaultAsync(io => io.Id == id);
            if(chan != null)
            {
                chanells.Remove(chan);
                await database.SaveChangesAsync();
            }
        }

        public async Task Update(Chanell item)
        {
            var cha = await chanells.FirstOrDefaultAsync(io => io.Name == item.Name);
            
            if(cha != null)
            {
                chanells.Entry(cha).CurrentValues.SetValues(item);
                await database.SaveChangesAsync();
            }
        }
    }
}

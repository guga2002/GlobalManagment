using DatabaseOperations.Interfaces;
using DDL.Database_Layer.Entities;
using Interfaces;
using Jandag.DLL.Data;
using Jandag.DLL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repositories
{
    public class TranscoderReporitory : BaseRepository, ITranscoderRepository
    {
        private readonly DbSet<Transcoder> Transcoder;
        public TranscoderReporitory(GlobalTvDb db) : base(db)
        {
            this.Transcoder = database.Set<Transcoder>();
        }

        public async Task Add(Transcoder item)
        {
            if (! await Transcoder.AnyAsync(io => io.Source_ID == item.Source_ID))
            {
                await Transcoder.AddAsync(item);
                await database.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Transcoder>> GetAll()
        {
            return await Transcoder.AsNoTracking().ToListAsync();
        }

        public async Task<Transcoder> GetById(int id)
        {
            var res=await Transcoder.FirstOrDefaultAsync(io=>io.Id == id);
            if(res is not null)
            {
                return res;
            }
            return null;
        }

        public async Task<Source> GetChanellIdBycardandport(int card, int port)
        {
            var res = await Transcoder.FirstOrDefaultAsync(io => io.Card == card&&io.Port==port);
            if (res is not null && res.Source is not null)
            {
                return res.Source;
            }
            return null;
        }

        public async Task Remove(int id)
        {
            var res = await Transcoder.FirstOrDefaultAsync(io => io.Id == id);
            if(res is not null)
            {
                Transcoder.Remove(res);
                await database.SaveChangesAsync();
            }
        }

        public async Task Update(Transcoder item)
        {
            var res = await Transcoder.FirstOrDefaultAsync(io => io.Source_ID == item.Source_ID);
            if (res is not null)
            {
                Transcoder.Entry(res).CurrentValues.SetValues(item);
                await database.SaveChangesAsync();
            }
        }
    }
}

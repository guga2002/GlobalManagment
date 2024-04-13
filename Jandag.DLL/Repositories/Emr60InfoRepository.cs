using DDL.Database_Layer.Entities;
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
    public class Emr60InfoRepository : BaseRepository, IEmr60Info
    {
        private readonly DbSet<Emr60Info> _dbSet;
        public Emr60InfoRepository(GlobalTvDb db):base(db)
        {
                _dbSet=database.Set<Emr60Info>();
        }

        public async Task<Emr60Info> GetEmrNumberBport(string port)
        {
           var res= await _dbSet.FirstOrDefaultAsync(io=>io.Port==port);
            if(res is not null)
            {
                return res;
            }
            return null;
        }
    }
}

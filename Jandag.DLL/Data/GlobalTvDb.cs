using DDL.Database_Layer.Entities;
using Jandag.DLL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.DLL.Data
{
    public class GlobalTvDb:IdentityDbContext<User>
    {
        public GlobalTvDb(DbContextOptions<GlobalTvDb>ops):base(ops)
        {
                
        }
        public virtual DbSet<Chanell> Chanels { get; set; }
        public virtual DbSet<Desclambler> Desclamblers { get; set; }
        public virtual DbSet<DesclamlerCard> DesclamlerCards { get; set; }
        public virtual DbSet<Emr60Info> Emr60Infos { get; set; }
        public virtual DbSet<Source> Sources { get; set; }
        public virtual DbSet<Transcoder> Transcoders { get; set; }
    }
}

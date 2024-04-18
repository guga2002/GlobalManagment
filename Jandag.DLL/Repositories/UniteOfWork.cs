using DatabaseOperations.Interfaces;
using Interfaces;
using Jandag.DLL.Data;
using Jandag.DLL.Interfaces;
using Jandag.DLL.Repositories.UserRelated;
using Repositories;
using Speaker.leison.Database_Layer.Interfaces;
using Speaker.leison.Database_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.DLL.Repositories
{
    public class UniteOfWork : BaseRepository, IUniteOfWork
    {
        public UniteOfWork(GlobalTvDb database) : base(database)
        {
        }

        public IChanellRepository ChanellRepository => new ChanellRepository(database);

        public IDesclamlerCard desclamlerCardRepository => new DesclamlerCardRepository(database);

        public IDesclambler desclamblerRepository => new DesclamblerRepository(database);


        public IEmr60Info emr60InfoRepository => new Emr60InfoRepository(database);

        public ISourceRepository sourceRepository => new SourceRepository(database);

        public ITranscoderRepository transcoderRepository => new TranscoderReporitory(database);

        public ISatteliteFrequency satteliterFrequencyRepository => new SatteliteFrequencyRepository(database);

        public async Task CommitAndSavechanges()
        {
            try
            {
                 await database.SaveChangesAsync();
                 await database.Database.CommitTransactionAsync();
            }
            catch (Exception)
            {
                await database.Database.RollbackTransactionAsync();
            }
        }

        public void Dispose()
        {
           database.Dispose();
        }
    }
}

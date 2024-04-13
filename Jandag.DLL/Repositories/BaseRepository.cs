using Jandag.DLL.Data;

namespace Repositories
{
    public abstract class BaseRepository
    {
        public readonly GlobalTvDb database;
        protected BaseRepository(GlobalTvDb database)
        {
            this.database = database;
        }
    }
}

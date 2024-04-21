
using DDL.Database_Layer.Entities;
using Jandag.DLL.Entities;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IChanellRepository:BaseInterface<Chanell>
    {
        Task Remove(string name);
        Task<Chanell> GetCHanellByName(string name);
        Task<bool> addSource(string name, Source sr);
    }
}

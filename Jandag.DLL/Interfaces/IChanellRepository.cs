
using DDL.Database_Layer.Entities;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IChanellRepository:BaseInterface<Chanell>
    {
        Task Remove(string name);
    }
}

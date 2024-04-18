using DDL.Database_Layer.Entities;
using Interfaces;
using Jandag.DLL.Entities;
using System.Threading.Tasks;

namespace DatabaseOperations.Interfaces
{
    public interface ITranscoderRepository : BaseInterface<Transcoder>
    {
        Task<Source> GetChanellIdBycardandport(int card, int port);
        Task Remove(int emrNumber, int card, int port);
    }
}

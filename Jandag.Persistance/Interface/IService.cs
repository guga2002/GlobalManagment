using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.Persistance.Interface
{
    public interface IService
    {
        Task<Dictionary<int, string>> GetChanellNames();
        Task<List<int>> GetPortsWhereAlarmsIsOn();
    }
}

using Interfaces;
using Jandag.DLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.DLL.Interfaces
{
    public interface ISatteliteFrequency:BaseInterface<SatteliteFrequency>
    {
        Task<SatteliteFrequency?> GetByIdIds(int id);
    }
}

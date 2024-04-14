using Interfaces;
using Jandag.DLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.DLL.Interfaces
{
    public interface ISourceRepository:BaseInterface<Source>
    {
        Task<Source> GetBychanellName(string name);
    }
}

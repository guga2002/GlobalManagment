using Jandag.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Interface
{
    public interface IChanellServices:IcrudService<ChanellModel>
    {
        Task<bool> DeleteByName(string Name);
    }
}

using DDL.Database_Layer.Entities;
using Jandag.BLL.Models;
using Jandag.DLL.Entities;
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
        Task<Chanell> GetCHanellByName(string name);
        Task<bool> addSource(string name, Source sr);
    }
}

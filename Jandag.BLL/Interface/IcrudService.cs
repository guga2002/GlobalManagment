using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Interface
{
    public interface IcrudService<T>where T:class
    {
        Task<bool> AddAsync(T Item);
        Task<bool> UpdateAsync(T item);
        Task<bool> Delete(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}

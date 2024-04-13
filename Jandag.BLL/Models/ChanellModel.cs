using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Models
{
    public class ChanellModel
    {
        public required string Name { get; set; }
        public IEnumerable<SourceModel> Sources { get; set; }
    }
}

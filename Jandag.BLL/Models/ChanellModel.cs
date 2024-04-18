using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Models
{
    public class ChanellModel
    {
        public int  ID { get; set; }
        public required string Name { get; set; }
        public List<SourceModel> Sources { get; set; } = new List<SourceModel>();
    }
}

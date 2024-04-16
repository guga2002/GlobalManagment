using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Models.ViewModels
{
    public class UniteChanellNamesAndAlarms
    {
        public Dictionary<int, string> namees {get;set;}

        public List<int> ports { get; set;}
    }
}

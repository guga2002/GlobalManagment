using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Models.ViewModels
{
    public class SatteliteViewMonitoring
    {
        public string Degree { get; set; }

        public List<SatteliteFrequencyModel> details { get; set; }
    }
}

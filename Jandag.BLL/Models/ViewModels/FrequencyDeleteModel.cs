using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Models.ViewModels
{
    public class FrequencyDeleteModel
    {
        public string Degree { get; set; }

        public int SymbolRate { get; set; }

        public int Frequency { get; set; }

        public char? Polarization { get; set; }

        public int PortIn250 { get; set; }
    }
}

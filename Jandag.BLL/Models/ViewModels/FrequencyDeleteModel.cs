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

        public string? SymbolRate { get; set; }

        public string? Frequency { get; set; }

        public char? Polarization { get; set; }

        public int PortIn250 { get; set; }
    }
}

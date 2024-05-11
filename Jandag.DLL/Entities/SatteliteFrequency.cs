using DDL.Database_Layer.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jandag.DLL.Entities
{
    [Table("SatteliteFrequencies")]
    public class SatteliteFrequency:AbstractEntity
    {
        public string? Degree { get; set; }
        public int Frequency { get; set; }
        public int SymbolRate { get; set; }
        public char? Polarisation { get; set; }
        public int PortIn250 { get; set; }
        public int EmrNumber { get; set; }
        public int portNumber { get; set; }
        public int CardNumber { get; set; }

        public virtual IEnumerable<Source> Sources { get; set; }
    }
}

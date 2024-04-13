using Jandag.DLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDL.Database_Layer.Entities
{
    public class Reciever : AbstractEntity
    {
        [Column("Emr_Number")]
        public  int EmrNumber { get; set; }

        [Column("Frequency_Stream")]
        public string Frequency  { get; set; }

        [Column("Card_In_Reciever")]
        public  int Card { get; set; }

        [Column("Port_In_Reciever")]
        public  int Port { get; set; }

        [Column("Is_From_Optic")]
        public  bool FromOptic { get; set; }
        public virtual IEnumerable<Source> Sources { get; set; }
    }
}

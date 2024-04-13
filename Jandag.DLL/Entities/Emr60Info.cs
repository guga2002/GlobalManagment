using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDL.Database_Layer.Entities
{
    [Table("Emr60infos")]
    public class Emr60Info : AbstractEntity
    {
        [Column("Reciever_port")]
        public string Port { get; set; }
        [Column("Source_emr")]
        public int SourceEmr { get; set; }
    }
}

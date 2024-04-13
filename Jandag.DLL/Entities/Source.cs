using DDL.Database_Layer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.DLL.Entities
{
    [Table("Sources")]
    public class Source:AbstractEntity
    {
        [Column("ChanellFormat")]
        public  string ChanellFormat { get; set; }

        [Column("IsActive")]
        public bool Status { get; set; }

        [ForeignKey("chanell")]
        public int ChanellId { get; set; }
        public Chanell chanell { get; set; }

        [Column("Reciever_Id")]
        [ForeignKey("Reciever")]
        public int Reciever_ID { get; set; }
        public Reciever Reciever { get; set; }
        public Transcoder Transcoder { get; set; }
        public Desclambler Desclambler { get; set; }
 
    }
}

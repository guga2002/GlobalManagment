﻿using DDL.Database_Layer.Entities;
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
        public Transcoder Transcoder { get; set; }
        public Desclambler Desclambler { get; set; }

        [ForeignKey("sattelite")]
        public int?  SatteliteId { get; set; }
        public SatteliteFrequency sattelite { get; set; }
        public string sourceName { get; set; }
        public string card { get; set; }
        public string port { get; set; }
        public int EmrNumber { get; set; }
    }
}

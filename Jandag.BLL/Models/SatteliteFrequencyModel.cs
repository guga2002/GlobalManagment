﻿using DDL.Database_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Models
{
    public class SatteliteFrequencyModel
    {
        public int  Id { get; set; }
        public string? Degree { get; set; }
        public int Frequency { get; set; }
        public int SymbolRate { get; set; }
        public char? Polarisation { get; set; }
        public int PortIn250 { get; set; }
        public bool HaveError { get; set; } = false;

        public string chanellIds { get; set; }= "";
        public List<ChanellModel> chanellid { get; set; } = new List<ChanellModel>();
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Models
{
    public class TranscoderModel
    {
        public int EmrNumber { get; set; }
        public int Card { get; set; }
        public int Port { get; set; }
        public Guid Source_ID { get; set; }
    }
}
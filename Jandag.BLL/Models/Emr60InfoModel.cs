using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Models
{
    public class Emr60InfoModel
    {
        public string Port { get; set; }
        public int SourceEmr { get; set; }
    }
}

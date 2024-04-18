using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Models
{
    public class SourceModel
    {
        public int  Id { get; set; }
        public required string ChanellFormat { get; set; }
        public bool Status { get; set; }
        public int ChanellId { get; set; }
        public int? Reciever_ID { get; set; }
    }
}

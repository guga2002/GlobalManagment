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
        public required string ChanellFormat { get; set; }
        public bool Status { get; set; }
        public Guid ChanellId { get; set; }
        public Guid Reciever_ID { get; set; }
    }
}

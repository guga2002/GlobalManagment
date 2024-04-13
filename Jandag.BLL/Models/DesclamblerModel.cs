using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Models
{
    public class DesclamblerModel
    {
        public required int EmrNumber { get; set; }
        public required int Card { get; set; }
        public required int Port { get; set; }

        public Guid Source_ID { get; set; }
        public virtual IEnumerable<DesclamlerCardModel> DescCard { get; set; }
    }
}

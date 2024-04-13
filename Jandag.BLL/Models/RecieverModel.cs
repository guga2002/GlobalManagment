using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Models
{
    public class RecieverModel
    {
        public required int EmrNumber { get; set; }
        public string Frequency { get; set; }

        public required int Card { get; set; }

        public required int Port { get; set; }

        public required bool FromOptic { get; set; }
        public virtual IEnumerable<SourceModel> Sources { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Models
{
    public class DesclamlerCardModel
    {
        public required string CardManufacturer { get; set; }
        public required string CardCode { get; set; }

        public Guid DesclamblerId { get; set; }

        public DesclamblerModel desclambler { get; set; }
    }
}

using DDL.Database_Layer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.DLL.Entities
{
    [Table("DesclamlerCards")]
    public class DesclamlerCard:AbstractEntity
    {
        [Column("Card_Manufacturer")]
        public  string CardManufacturer { get; set; }

        [Column("Card_Code")]
        public  string CardCode { get; set; }

        [ForeignKey("desclambler")]
        public int DesclamblerId { get; set; }

        public Desclambler desclambler { get; set; }
    }
}

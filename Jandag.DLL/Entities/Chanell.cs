using Jandag.DLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDL.Database_Layer.Entities
{

    [Table("Chanells")]
    public class Chanell:AbstractEntity
    { 
        [Column("Name_Of_Chanell")]
        public  string Name { get; set; }
        public virtual  IEnumerable<Source> Sources { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.DLL.Entities
{
    [Table("Users")]
    [Index(nameof(PersonalNumber),IsUnique =true)]
    public class User:IdentityUser
    {
        [Column("PersonalNumber")]
        public   string PersonalNumber { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("Surname")]
        public string Surname { get; set; }

        [Column("Birthdate")]
        public DateTime Birthdate { get; set; }

    }
}

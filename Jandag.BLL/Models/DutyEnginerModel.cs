using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Models
{
    public class DutyEnginerModel 
    {
        public string SelectedOption { get; set; }
        public List<SelectListItem> OptionList { get; set; }
    }
}

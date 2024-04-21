using Microsoft.AspNetCore.Mvc.Rendering;

namespace Jandag.BLL.Models
{
    public class DutyEnginerModel 
    {
        public string SelectedOption { get; set; }
        public List<SelectListItem> OptionList { get; set; }
    }
}

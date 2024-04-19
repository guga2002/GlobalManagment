using Jandag.BLL.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Interface
{
    public interface ITranscoderService:IcrudService<TranscoderViewModel>
    {
        Task Remove(int emrNumber, int card, int port);
        Task<TranscoderViewModel> GetDropDownList();
    }
}

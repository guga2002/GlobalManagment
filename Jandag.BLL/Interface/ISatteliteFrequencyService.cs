using Jandag.BLL.Models;
using Jandag.BLL.Models.ViewModels;

namespace Jandag.BLL.Interface
{
    public interface ISatteliteFrequencyService : IcrudService<SatteliteFrequencyModel>
    {
        Task<IEnumerable<SatteliteViewMonitoring>> GetMonitoringFrequencies();
        Task<SatteliteFrequencyModel> GetDetailsByEmrport(int PortId);
        Task<List<int>> GetAllarmsFromRegion();
    }
}

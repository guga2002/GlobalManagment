using Jandag.BLL.Models.ViewModels;

namespace Jandag.BLL.Models
{
    public class UniteModel
    {
        public UniteChanellNamesAndAlarms chyanellnameandalarm { get; set; }
        public IEnumerable<SatteliteViewMonitoring> satelliteview { get; set; }
    }
}

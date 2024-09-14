namespace Jandag.BLL.Interface
{
    public interface ITemperatureService
    {
        Task<(string,string)> GetCUrrentTemperature();
    }
}

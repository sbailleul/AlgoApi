namespace AlgoApi.Core.TemperatureUpdating
{
    public interface ITemperatureUpdater
    {
        float UpdateTemperature(float temperature, float variance);
    }
}
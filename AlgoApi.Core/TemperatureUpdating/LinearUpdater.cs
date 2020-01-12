namespace AlgoApi.Core.TemperatureUpdating
{
    public class LinearUpdater : ITemperatureUpdater
    {
        public float UpdateTemperature(float temperature, float variance)
        {
            return temperature - variance;
        }
    }
}
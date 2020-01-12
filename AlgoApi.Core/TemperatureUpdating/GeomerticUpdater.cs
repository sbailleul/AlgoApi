namespace AlgoApi.Core.TemperatureUpdating
{
    public class GeomerticUpdater : ITemperatureUpdater
    {
        public float UpdateTemperature(float temperature, float variance)
        {
            return temperature * variance;
        }
    }
}
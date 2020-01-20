using AlgoApi.Core.TemperatureUpdating;
using NUnit.Framework;

namespace AlgoApi.Test.Core.TemperatureUpdating
{
    [TestFixture]
    public class ITemperatureUpdaterTests
    {
        [Test]
        public void GeometricUpdater()
        {
            var updater = new GeomerticUpdater();
            Assert.AreEqual(2.0f * 0.9f, updater.UpdateTemperature(2.0f, 0.9f));
        }

        [Test]
        public void LinearUpdater()
        {
            var updater = new LinearUpdater();
            Assert.AreEqual(2.0f - 0.9f, updater.UpdateTemperature(2.0f, 0.9f));
        }
    }
}
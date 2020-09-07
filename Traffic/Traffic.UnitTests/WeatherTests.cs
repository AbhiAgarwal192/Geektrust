using Traffic.Entities;
using Traffic.Constants;
using Xunit;

namespace Traffic.UnitTests
{
    public class WeatherTests
    {
        private Weather _weather;
        public WeatherTests()
        {
            _weather = new Weather(WeatherConditions.WINDY, -0.1);
        }

        [Fact]
        public void GivenWeatherCondition_WhenAddVehicleIsCalled_ThenVehicleShouldBeAdded()
        {
            var car = new Vehicle(20, 3, VehicleType.Car);
            _weather.AddVehicle(car);
            Assert.NotNull(_weather.UsableVehicles);
            Assert.True(_weather.UsableVehicles.Count == 1);
            Assert.Equal(VehicleType.Car,_weather.UsableVehicles[0].Type);
        }
    }
}

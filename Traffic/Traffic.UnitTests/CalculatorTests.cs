using Traffic.Entities;
using Traffic.Constants;
using Xunit;

namespace Traffic.UnitTests
{
    public class CalculatorTests
    {
        private Calculator _calculator;
        private Orbit orbitOne;
        private Orbit orbitTwo;
        public CalculatorTests()
        {
            _calculator = new Calculator();
            orbitOne = new Orbit(18, 20, "ORBIT1");
            orbitTwo = new Orbit(20, 10, "ORBIT2");
        }

        [Theory]
        [InlineData("SUNNY", 12, 10, VehicleType.TukTuk, "ORBIT1")]
        [InlineData("WINDY", 14, 20, VehicleType.Car, "ORBIT2")]
        [InlineData("RAINY", 8, 15, VehicleType.TukTuk, "ORBIT2")]
        public void GiveOrbitTrafficSpeedsAndWeatherConditions_ThenReturnTheVehicleAndOrbitCombination(string weather, double orbit1, double orbit2, VehicleType vehicle, string orbit)
        {
            var orb = _calculator.FastestRouteToReachDestination(weather,orbit1,orbit2, out Vehicle veh);
            Assert.NotNull(orb);
            Assert.NotNull(veh);
            Assert.Equal(orbit,orb.Name);
            Assert.Equal(vehicle, veh.Type);
        }

        [Fact]
        public void GiveOrbitOneTrafficSpeedsAndWeatherConditions_ThenReturnTheTimeTakenForThatOrbit()
        {
            var time = _calculator.TimeTakenToReachDestination(WeatherConditions.SUNNY,orbitOne,10,out Vehicle veh);
            Assert.False(time == 0);
            Assert.NotNull(veh);
            Assert.True(time == 126);
            Assert.Equal(VehicleType.TukTuk, veh.Type);
        }

        [Fact]
        public void GiveOrbitTwoTrafficSpeedsAndWeatherConditions_ThenReturnTheTimeTakenForThatOrbit()
        {
            var time = _calculator.TimeTakenToReachDestination(WeatherConditions.SUNNY, orbitTwo, 10, out Vehicle veh);
            Assert.False(time == 0);
            Assert.NotNull(veh);
            Assert.True(time == 129);
            Assert.Equal(VehicleType.TukTuk, veh.Type);
        }
    }
}

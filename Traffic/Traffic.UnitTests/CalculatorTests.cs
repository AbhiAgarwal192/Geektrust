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

        [Theory]
        [InlineData(WeatherConditions.SUNNY,VehicleType.TukTuk, 126)]
        [InlineData(WeatherConditions.WINDY, VehicleType.Bike, 148)]
        [InlineData(WeatherConditions.RAINY, VehicleType.TukTuk, 132)]
        public void GiveOrbitOneTrafficSpeedsAndWeatherConditions_ThenReturnTheTimeTakenAndVehicleForThatOrbit(string weather, VehicleType vehicle, int time)
        {
            var t = _calculator.TimeTakenToReachDestination(weather, orbitOne,10,out Vehicle veh);
            Assert.NotNull(veh);
            Assert.True(time == t);
            Assert.Equal(vehicle, veh.Type);
        }

        [Theory]
        [InlineData(WeatherConditions.SUNNY, VehicleType.TukTuk, 129)]
        [InlineData(WeatherConditions.WINDY, VehicleType.Bike, 140)]
        [InlineData(WeatherConditions.RAINY, VehicleType.TukTuk, 132)]
        public void GiveOrbitTwoTrafficSpeedsAndWeatherConditions_ThenReturnTheTimeTakenAndVehicleForThatOrbit(string weather, VehicleType vehicle, int time)
        {
            var t = _calculator.TimeTakenToReachDestination(weather, orbitTwo, 10, out Vehicle veh);
            Assert.NotNull(veh);
            Assert.True(time == t);
            Assert.Equal(vehicle, veh.Type);
        }
    }
}

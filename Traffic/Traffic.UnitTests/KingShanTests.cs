using System;
using Traffic.Entities;
using Xunit;

namespace Traffic.UnitTests
{
    public class KingShanTests
    {
        private KingShan _kingShan;
        public KingShanTests()
        {
            _kingShan = new KingShan();
        }

        [Theory]
        [InlineData("SUNNY",12,10,"TUKTUK","ORBIT1")]
        [InlineData("WINDY", 14, 20, "CAR", "ORBIT2")]
        [InlineData("RAINY", 8, 15, "TUKTUK", "ORBIT2")]
        public void GiveOrbitTrafficSpeedsAndWeatherConditions_ThenReturnTheVehicleAndOrbitCombination(string weather, int orbit1, int orbit2, string vehicle, string orbit)
        {
            var result = _kingShan.DecideVehicle(weather,orbit1,orbit2);
            Assert.NotNull(result);
            var str = result.Split();
            Assert.True(str.Length == 2);
            Assert.Equal(vehicle,str[0]);
            Assert.Equal(orbit, str[1]);
        }
    }
}

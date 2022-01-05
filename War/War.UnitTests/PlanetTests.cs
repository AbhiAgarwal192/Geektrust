using War.Constants;
using War.Contracts;
using War.Entities;
using Xunit;

namespace War.UnitTests
{
    public class PlanetTests
    {
        private IRules _rules;
        public PlanetTests()
        {
            _rules = new Rules();
        }

        [Theory]
        [InlineData(100, 101, 20, 5, 52, 50, 10, 3)]
        [InlineData(150, 96, 26, 8, 75, 50, 10, 5)]
        [InlineData(250, 0, 0, 0, 100, 13, 0, 0)]
        [InlineData(0, 102, 0, 0, 2, 50, 0, 0)]
        [InlineData(0, 0, 22, 0, 0, 2, 10, 0)]
        [InlineData(0, 0, 0, 12, 0, 0, 2, 5)]
        [InlineData(250,50,3,1,100,38,2,1)]
        public void GivenFalicornianArmyAttacks__WhenKingShanHasSufficientBattalion_ThenKingShanWins(int i_horses, int i_elephants, int i_tanks, int i_guns,
                                                                                                    int o_horses, int o_elephants, int o_tanks, int o_guns)
        {
            var lengaburu = new Planet(Kingdom.LENGABURU,LengaburuArmy.HORSES,LengaburuArmy.ELEPHANTS,LengaburuArmy.TANKS,LengaburuArmy.GUNS,this._rules);
            var falconianArmy = new Army(i_horses, i_elephants, i_tanks, i_guns);
            var result = lengaburu.Defends(falconianArmy);

            var output = result.Split(' ');
            Assert.Equal(Result.WINS, output[0]);
            Assert.Equal($"{o_horses}H",output[1]);
            Assert.Equal($"{o_elephants}E", output[2]);
            Assert.Equal($"{o_tanks}AT", output[3]);
            Assert.Equal($"{o_guns}SG", output[4]);
        }

        [Theory]
        //[InlineData(250, 50, 20, 15,100,38,10,5)]
        [InlineData(200,58, 18, 12, 100, 29, 10, 5)] //This one is failing. Debug
        public void GivenFalicornianArmyAttacks__WhenKingShanDoesNotHaveSufficientBattalion_ThenKingShanLoses(int i_horses, int i_elephants, int i_tanks, int i_guns,
                                                                                                    int o_horses, int o_elephants, int o_tanks, int o_guns)
        {
            var lengaburu = new Planet(Kingdom.LENGABURU, LengaburuArmy.HORSES, LengaburuArmy.ELEPHANTS, LengaburuArmy.TANKS, LengaburuArmy.GUNS, this._rules);
            var falconianArmy = new Army(i_horses, i_elephants, i_tanks, i_guns);
            var result = lengaburu.Defends(falconianArmy);
            var output = result.Split(' ');
            Assert.Equal(Result.LOSES, output[0]);
            Assert.Equal($"{o_horses}H", output[1]);
            Assert.Equal($"{o_elephants}E", output[2]);
            Assert.Equal($"{o_tanks}AT", output[3]);
            Assert.Equal($"{o_guns}SG", output[4]);
        }
    }
}

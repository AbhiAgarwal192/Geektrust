using War.Constants;
using War.Contracts;
using War.Entities;
using Xunit;

namespace War.UnitTests
{
    public class RulesTests
    {
        private IRules _rules;
        public RulesTests()
        {
            _rules = new Rules();
        }

        [Theory]
        [InlineData(50,25)]
        public void GivenFalicorniaAttacks_WhenKingSHanHasSufficientHorses_ThenApplyPowerRule(int i_horses, int o_horses)
        {
            var falconianArmy = new Army(i_horses, 0, 0, 0);
            var lengaburuArmy = new Army(LengaburuArmy.HORSES, LengaburuArmy.ELEPHANTS, LengaburuArmy.TANKS, LengaburuArmy.GUNS);
            var output = _rules.DetermineTroopsToDeploy(lengaburuArmy,falconianArmy,out string result);
            Assert.Equal(o_horses, output.Horses);
        }

        [Theory]
        [InlineData(50, 25)]
        public void GivenFalicorniaAttacks_WhenKingSHanHasSufficientElephants_ThenApplyPowerRule(int i_elephants, int o_elephants)
        {
            var falconianArmy = new Army(0, i_elephants, 0, 0);
            var lengaburuArmy = new Army(LengaburuArmy.HORSES, LengaburuArmy.ELEPHANTS, LengaburuArmy.TANKS, LengaburuArmy.GUNS);
            var output = _rules.DetermineTroopsToDeploy(lengaburuArmy, falconianArmy, out string result);
            Assert.Equal(o_elephants, output.Elephants);
        }

        [Theory]
        [InlineData(20, 10)]
        public void GivenFalicorniaAttacks_WhenKingSHanHasSufficientTanks_ThenApplyPowerRule(int i_tanks, int o_tanks)
        {
            var falconianArmy = new Army(0, 0, i_tanks, 0);
            var lengaburuArmy = new Army(LengaburuArmy.HORSES, LengaburuArmy.ELEPHANTS, LengaburuArmy.TANKS, LengaburuArmy.GUNS);
            var output = _rules.DetermineTroopsToDeploy(lengaburuArmy, falconianArmy, out string result);
            Assert.Equal(o_tanks, output.Tanks);
        }

        [Theory]
        [InlineData(10, 5)]
        public void GivenFalicorniaAttacks_WhenKingSHanHasSufficientGuns_ThenApplyPowerRule(int i_guns, int o_guns)
        {
            var falconianArmy = new Army(0, 0, 0, i_guns);
            var lengaburuArmy = new Army(LengaburuArmy.HORSES, LengaburuArmy.ELEPHANTS, LengaburuArmy.TANKS, LengaburuArmy.GUNS);
            var output = _rules.DetermineTroopsToDeploy(lengaburuArmy, falconianArmy, out string result);
            Assert.Equal(o_guns, output.Guns);
        }

        [Fact]
        public void GivenFalicorniaAttacks_WhenKingSHanHasSufficientBattalionOfEachUnit_ThenApplyLikeToLikeRule()
        {
            var falconianArmy = new Army(2, 4, 0, 6);
            var lengaburuArmy = new Army(LengaburuArmy.HORSES, LengaburuArmy.ELEPHANTS, LengaburuArmy.TANKS, LengaburuArmy.GUNS);
            var output = _rules.DetermineTroopsToDeploy(lengaburuArmy, falconianArmy, out string result);
            Assert.Equal(1, output.Horses);
            Assert.Equal(2, output.Elephants);
            Assert.Equal(0, output.Tanks);
            Assert.Equal(3, output.Guns);
        }

        [Theory]
        [InlineData(204,20,0,0,100,11,0,0)]
        [InlineData(0,0,14,12,0,0,9,5)]
        public void GivenFalicorniaAttacks_WhenKingShanDoesNotHaveSufficientBattalionOfEachUnit_ThenApplySubstitutionRule(int i_horses, int i_elephants, int i_tanks, int i_guns,
                                                                                                    int o_horses, int o_elephants, int o_tanks, int o_guns)
        {
            var falconianArmy = new Army(i_horses, i_elephants, i_tanks, i_guns);
            var lengaburuArmy = new Army(LengaburuArmy.HORSES, LengaburuArmy.ELEPHANTS, LengaburuArmy.TANKS, LengaburuArmy.GUNS);
            var output = _rules.DetermineTroopsToDeploy(lengaburuArmy, falconianArmy, out string result);
            Assert.Equal(o_horses, output.Horses);
            Assert.Equal(o_elephants, output.Elephants);
            Assert.Equal(o_tanks, output.Tanks);
            Assert.Equal(o_guns, output.Guns);
        }

        [Fact]
        public void GivenFalicorniaAttacks_WhenKingSHanHasSufficientBattalionOfEachUnit_ThenApplySubstitutionChoiceRule()
        {
            var falconianArmy = new Army(50, 104, 6, 2);
            var lengaburuArmy = new Army(LengaburuArmy.HORSES, LengaburuArmy.ELEPHANTS, LengaburuArmy.TANKS, LengaburuArmy.GUNS);
            var output = _rules.DetermineTroopsToDeploy(lengaburuArmy, falconianArmy, out string result);
            Assert.Equal(29, output.Horses);
            Assert.Equal(50, output.Elephants);
            Assert.Equal(3, output.Tanks);
            Assert.Equal(1, output.Guns);
        }
    }
}

using TameOfThrones.Constants;
using TameOfThrones.Entities;
using Xunit;

namespace TameOfThrones.UnitTests
{
    public class SoutherosTests
    {
        private Southeros _southeros;
        public SoutherosTests()
        {
            _southeros = new Southeros();
        }
        [Fact]
        public void GivenKingdomNameIsSpace_WhenFindKingdomIsCalled_ReturnsSpaceKingdom()
        {
            var kingdom = _southeros.FindKingdom(KingdomNames.SPACE);
            Assert.NotNull(kingdom);
            Assert.Equal(KingdomNames.SPACE,kingdom.Name);
        }

        [Fact]
        public void GivenKingdomNameIsLand_WhenFindKingdomIsCalled_ReturnsLandKingdom()
        {
            var kingdom = _southeros.FindKingdom(KingdomNames.LAND);
            Assert.NotNull(kingdom);
            Assert.Equal(KingdomNames.LAND, kingdom.Name);
        }

        [Fact]
        public void GivenKingdomNameIsWater_WhenFindKingdomIsCalled_ReturnsWaterKingdom()
        {
            var kingdom = _southeros.FindKingdom(KingdomNames.WATER);
            Assert.NotNull(kingdom);
            Assert.Equal(KingdomNames.WATER, kingdom.Name);
        }
        [Fact]
        public void GivenKingdomNameIsIce_WhenFindKingdomIsCalled_ReturnsIceKingdom()
        {
            var kingdom = _southeros.FindKingdom(KingdomNames.ICE);
            Assert.NotNull(kingdom);
            Assert.Equal(KingdomNames.ICE, kingdom.Name);
        }

        [Fact]
        public void GivenKingdomNameIsAir_WhenFindKingdomIsCalled_ReturnsAirKingdom()
        {
            var kingdom = _southeros.FindKingdom(KingdomNames.AIR);
            Assert.NotNull(kingdom);
            Assert.Equal(KingdomNames.AIR, kingdom.Name);
        }

        [Fact]
        public void GivenKingdomNameIsFire_WhenFindKingdomIsCalled_ReturnsFireKingdom()
        {
            var kingdom = _southeros.FindKingdom(KingdomNames.FIRE);
            Assert.NotNull(kingdom);
            Assert.Equal(KingdomNames.FIRE, kingdom.Name);
        }

        [Fact]
        public void GivenKingdomNameWhichDoesNotExistInSoutheros_WhenFindKingdomIsCalled_ReturnsNull()
        {
            var kingdom = _southeros.FindKingdom("Westeros");
            Assert.Null(kingdom);
        }

        [Fact]
        public void GivenGorillaKingHasMoreThan3Allies_WhenDecideRulerIsCalled_ThenReturnTrue()
        {
            var spaceKingdom = new Kingdom(KingdomNames.SPACE, Emblems.Gorilla);
            var panda = new Kingdom(KingdomNames.LAND, Emblems.Panda);
            var octopus = new Kingdom(KingdomNames.WATER, Emblems.Octopus);
            var owl = new Kingdom(KingdomNames.AIR, Emblems.Owl);
            spaceKingdom.Allies.Add(panda);
            spaceKingdom.Allies.Add(octopus);
            spaceKingdom.Allies.Add(owl);
            var result = _southeros.DecideRuler(spaceKingdom);
            Assert.True(result);
        }

        [Fact]
        public void GivenGorillaKingHasLessThan3Allies_WhenDecideRulerIsCalled_ThenReturnFalse()
        {
            var spaceKingdom = new Kingdom(KingdomNames.SPACE, Emblems.Gorilla);
            var result = _southeros.DecideRuler(spaceKingdom);
            Assert.False(result);
        }
    }
}

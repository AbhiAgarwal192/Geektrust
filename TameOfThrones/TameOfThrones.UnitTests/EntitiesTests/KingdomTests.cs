using TameOfThrones.Constants;
using TameOfThrones.Entities;
using Xunit;

namespace TameOfThrones.UnitTests.EntitiesTests
{
    public class KingdomTests
    {
        private Kingdom _kingdom;
        public KingdomTests()
        {
            _kingdom = new Kingdom(KingdomNames.AIR, Emblems.Owl);
        }

        [Fact]
        public void GivenACorrectlyEncryptedMessageIsReceived_WhenIsAllyIsCalled_ShouldReturnTrue()
        {
            var output = _kingdom.IsAlly("ROZO");
            Assert.True(output);
        }

        [Fact]
        public void GivenAIncorrectlyEncryptedMessageIsReceived_WhenIsAllyIsCalled_ShouldReturnFalse()
        {
            var output = _kingdom.IsAlly("ABCD");
            Assert.False(output);
        }

        [Fact]
        public void WhenAKingdomWantsToMakeAlliesAndSendsCorrectMessage_ThenHeShouldBeAbleToSendMessagesAndIncreaseAllies()
        {
            var kingdom = new Kingdom(KingdomNames.SPACE,Emblems.Gorilla);
            kingdom.SendMessage(_kingdom,"ROZO");
            Assert.True(kingdom.Allies.Count == 1);
            Assert.Equal(_kingdom.Name,kingdom.Allies[0].Name);
        }

        [Fact]
        public void WhenAKingdomWantsToMakeAlliesAndSendsIncorrectMessage_ThenHeShouldBeAbleToSendMessagesAndIncreaseAllies()
        {
            var kingdom = new Kingdom(KingdomNames.SPACE, Emblems.Gorilla);
            kingdom.SendMessage(_kingdom, "ABC");
            Assert.True(kingdom.Allies.Count == 0);
        }
    }
}

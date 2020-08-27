using TameOfThrones.Constants;
using TameOfThrones.Entities;
using Xunit;

namespace TameOfThrones.UnitTests.EntitiesTests
{
    public class MessageTests
    {
        private Message _message;
        public MessageTests()
        {
            _message = new Message();
        }

        [Fact]
        public void GivenMessageCorrectlyEncrypted_WhenVerifyIsCalled_ShouldReturnTrue()
        {
            var status = _message.Verify("ROZO",Emblems.Owl.ToUpper());
            Assert.True(status);
        }

        [Fact]
        public void GivenMessageIncorrectlyEncrypted_WhenVerifyIsCalled_ShouldReturnFalse()
        {
            var status = _message.Verify("ROZO", Emblems.Gorilla);
            Assert.False(status);
        }
    }
}

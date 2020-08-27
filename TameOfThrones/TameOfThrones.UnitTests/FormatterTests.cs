using TameOfThrones.Constants;
using Xunit;

namespace TameOfThrones.UnitTests
{
    public class FormatterTests
    {
        private Formatter _formatter;
        public FormatterTests()
        {
            _formatter = new Formatter();
        }

        [Fact]
        public void GivenInputIsEmptyList_ShouldReturnEmptyString()
        {
            var output = _formatter.Format(new System.Collections.Generic.List<Entities.Kingdom>());
            Assert.NotNull(output);
            Assert.Equal(string.Empty,output);
        }

        [Fact]
        public void GivenInputIsListOfKindom_ShouldConvertToString()
        {
            var ally = new System.Collections.Generic.List<Entities.Kingdom>();
            ally.Add(new Entities.Kingdom(KingdomNames.AIR,Emblems.Owl));
            var output = _formatter.Format(ally);
            Assert.NotNull(output);
            Assert.Equal(KingdomNames.AIR,output);
        }
    }
}

using FamilyTree.Handlers;
using FamilyTree.UnitTests.Fixtures;
using Xunit;

namespace FamilyTree.UnitTests.HandlerTests
{
    public class SisterInLawHandlerTests : IClassFixture<FamilyTreeFixture>
    {
        private SisterInLawHandler _handler;
        private FamilyTreeFixture _fixture;
        public SisterInLawHandlerTests(FamilyTreeFixture fixture)
        {
            _handler = new SisterInLawHandler();
            _fixture = fixture;
        }

        [Fact]
        public void GivenRelationshipExists_ShouldReturnData()
        {
            var jaya = _fixture.Jaya;
            var sisterInLaw = _handler.Process(jaya);
            Assert.NotNull(sisterInLaw);
            Assert.True(sisterInLaw.Count == 1);
            Assert.True((sisterInLaw[0] == "Tritha"));
        }

        [Fact]
        public void GivenRelationshipDoesNotExists_ShouldReturnEmptyList()
        {
            var yodhan = _fixture.Yodhan;
            var brotherInLaw = _handler.Process(yodhan);
            Assert.NotNull(brotherInLaw);
            Assert.True(brotherInLaw.Count == 0);
        }
    }
}

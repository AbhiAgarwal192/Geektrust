using FamilyTree.Handlers;
using FamilyTree.UnitTests.Fixtures;
using Xunit;

namespace FamilyTree.UnitTests.HandlerTests
{
    public class BrotherInLawHandlerTests : IClassFixture<FamilyTreeFixture>
    {
        private BrotherInLawHandler _handler;
        private FamilyTreeFixture _fixture;
        public BrotherInLawHandlerTests(FamilyTreeFixture fixture)
        {
            _handler = new BrotherInLawHandler();
            _fixture = fixture;
        }

        [Fact]
        public void GivenRelationshipExists_ShouldReturnData()
        {
            var tritha = _fixture.tritha;
            var brotherInLaw = _handler.Process(tritha);
            Assert.NotNull(brotherInLaw);
            Assert.True(brotherInLaw.Count == 1);
            Assert.True((brotherInLaw[0] == "Jaya"));
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

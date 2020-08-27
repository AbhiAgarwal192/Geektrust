using FamilyTree.Handlers;
using FamilyTree.UnitTests.Fixtures;
using Xunit;

namespace FamilyTree.UnitTests.HandlerTests
{
    public class DaughterHandlerTests : IClassFixture<FamilyTreeFixture>
    {
        private DaughterHandler _daughterHandler;
        private FamilyTreeFixture _fixture;
        public DaughterHandlerTests(FamilyTreeFixture fixture)
        {
            _daughterHandler = new DaughterHandler();
            _fixture = fixture;
        }

        [Fact]
        public void GivenRelationshipExistsAndAccessingThroughMother_ShouldReturnData()
        {
            var lika = _fixture.lika;
            var daughter = _daughterHandler.Process(lika);
            Assert.NotNull(daughter);
            Assert.True(daughter.Count == 2);
            Assert.True((daughter[0] == "Vila") || (daughter[0] == "Chika"));
            Assert.True((daughter[1] == "Vila") || (daughter[1] == "Chika"));
        }

        [Fact]
        public void GivenRelationshipExistsAndAccessingThroughFather_ShouldReturnData()
        {
            var vich = _fixture.vich;
            var daughter = _daughterHandler.Process(vich);
            Assert.NotNull(daughter);
            Assert.True(daughter.Count == 2);
            Assert.True((daughter[0] == "Vila") || (daughter[0] == "Chika"));
            Assert.True((daughter[1] == "Vila") || (daughter[1] == "Chika"));
        }

        [Fact]
        public void GivenRelationshipDoesNotExists_ShouldReturnEmptyList()
        {
            var yodhan = _fixture.Yodhan;
            var daughter = _daughterHandler.Process(yodhan);
            Assert.NotNull(daughter);
            Assert.True(daughter.Count == 0);
        }
    }
}

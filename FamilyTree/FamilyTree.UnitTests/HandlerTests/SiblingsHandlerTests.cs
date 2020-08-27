using FamilyTree.Handlers;
using FamilyTree.UnitTests.Fixtures;
using Xunit;

namespace FamilyTree.UnitTests.HandlerTests
{
    public class SiblingsHandlerTests : IClassFixture<FamilyTreeFixture>
    {
        private SiblingsHandler _siblingsHandler;
        private FamilyTreeFixture _fixture;
        public SiblingsHandlerTests(FamilyTreeFixture fixture)
        {
            _siblingsHandler = new SiblingsHandler();
            _fixture = fixture;
        }

        [Fact]
        public void GivenRelationshipExists_ShouldReturnData()
        {
            var vila = _fixture.Vila;
            var siblings = _siblingsHandler.Process(vila);
            Assert.NotNull(siblings);
            Assert.True(siblings.Count == 1);
            Assert.Equal("Chika",siblings[0]);
        }

        [Fact]
        public void GivenRelationshipDoesNotExists_ShouldReturnEmptyList()
        {
            var yodhan = _fixture.Yodhan;
            var siblings = _siblingsHandler.Process(yodhan);
            Assert.NotNull(siblings);
            Assert.True(siblings.Count == 0);
        }

    }
}

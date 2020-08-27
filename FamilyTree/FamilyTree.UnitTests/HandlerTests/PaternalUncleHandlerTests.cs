using FamilyTree.Handlers;
using FamilyTree.UnitTests.Fixtures;
using Xunit;

namespace FamilyTree.UnitTests.HandlerTests
{
    public class PaternalUncleHandlerTests : IClassFixture<FamilyTreeFixture>
    {
        private PaternalUncleHandler _handler;
        private FamilyTreeFixture _fixture;
        public PaternalUncleHandlerTests(FamilyTreeFixture fixture)
        {
            _handler = new PaternalUncleHandler();
            _fixture = fixture;
        }

        [Fact]
        public void GivenRelationshipExists_ShouldReturnData()
        {
            var vasa = _fixture.vasa;
            var paternalUncle = _handler.Process(vasa);
            Assert.NotNull(paternalUncle);
            Assert.True(paternalUncle.Count == 1);
            Assert.True((paternalUncle[0] == "Vyas"));
        }

        [Fact]
        public void GivenRelationshipDoesNotExists_ShouldReturnEmptyList()
        {
            var yodhan = _fixture.Yodhan;
            var paternalUncle = _handler.Process(yodhan);
            Assert.NotNull(paternalUncle);
            Assert.True(paternalUncle.Count == 0);
        }
    }
}

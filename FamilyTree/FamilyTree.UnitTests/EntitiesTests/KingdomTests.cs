using FamilyTree.UnitTests.Fixtures;
using Xunit;

namespace FamilyTree.UnitTests.EntitiesTest
{
    public class KingdomTests : IClassFixture<FamilyTreeFixture>
    {
        private FamilyTreeFixture _fixture;
        public KingdomTests(FamilyTreeFixture fixture)
        {
            _fixture = fixture;
        }
        [Fact]
        public void GivenNameWhichExistsInFamily_ShouldReturnPerson()
        {
            var child = _fixture.Kingdom.FindChild("Chit");
            Assert.NotNull(child);
            Assert.Equal("Chit",child.Name);
        }

        [Fact]
        public void GivenNameWhichDoesNotExistInFamily_ShouldReturnNull()
        {
            var child = _fixture.Kingdom.FindChild("SomeDummyName");
            Assert.Null(child);
        }
    }
}

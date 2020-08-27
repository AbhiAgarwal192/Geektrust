using FamilyTree.Constants;
using FamilyTree.UnitTests.Fixtures;
using FamilyTree.Utilities;
using Xunit;

namespace FamilyTree.UnitTests
{
    public class OperationsTests : IClassFixture<FamilyTreeFixture>
    {
        private FamilyTreeFixture _fixture;
        private Operation _operation;
        public OperationsTests(FamilyTreeFixture fixture)
        {
            _fixture = fixture;
            _operation = new Operation(_fixture.Kingdom);
        }

        [Fact]
        public void GivenPersonDoesNotExist_WhenAnyOperationIsPerformed_ThenReturnPersonNotFound()
        {
            string[] args = {"ADD_CHILD","Rahul","Mohita", "Female" };
            var result = _operation.Perform(args);
            Assert.NotNull(result);
            Assert.Equal(Message.PersonNotFound,result);
        }

        [Fact]
        public void GivenAddChildOperation_WhenCalledOnFather_ThenReturnOperationFailedMessage()
        {
            string[] args = { "ADD_CHILD", "Shan", "Mohita", "Female" };
            var result = _operation.Perform(args);
            Assert.NotNull(result);
            Assert.Equal(Message.ChildAdditionFailed, result);
        }

        [Fact]
        public void GivenAddChildOperation_WhenCalledOnMother_ThenReturnOperationSuccessMessage()
        {
            string[] args = { "ADD_CHILD", "Anga", "Mohita", "Female" };
            var result = _operation.Perform(args);
            Assert.NotNull(result);
            Assert.Equal(Message.ChildAdditionSuccessful, result);
        }

        [Fact]
        public void GivenAPersonExistsInTheFamily_WhenGetRelationshipIsPerformed_ThenReturnRelationship()
        {
            string[] args = { "GET_RELATIONSHIP", "Anga", "Son"};
            var result = _operation.Perform(args);
            Assert.NotNull(result);
        }
    }
}

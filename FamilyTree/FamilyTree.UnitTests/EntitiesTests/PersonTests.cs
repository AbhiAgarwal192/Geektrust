using FamilyTree.Entities;
using FamilyTree.Enums;
using Xunit;

namespace FamilyTree.UnitTests.EntitiesTest
{
    public class PersonTests
    {
        private Person anga, shan;
        public PersonTests()
        {
            anga = new Person("Anga", Gender.Female, null, null);
            shan = new Person("Shan", Gender.Male, null, null);
            anga.AddSpouse(shan);
            shan.AddSpouse(anga);
        }
        [Fact]
        public void GivenAPersonIsMarried_WhenIsMarriedIsCalled_ShouldReturnTrue()
        {
            Assert.True(anga.IsMarried());
            Assert.True(shan.IsMarried());
        }

        [Fact]
        public void GivenAPerson_WhenAddSpouseIsCalled_ThenSpouseShouldGetAdded()
        {
            var anga = new Person("Anga", Gender.Female, null, null);
            var shan = new Person("Shan", Gender.Male, null, null);
            anga.AddSpouse(shan);
            shan.AddSpouse(anga);
            Assert.NotNull(anga.Spouse);
            Assert.NotNull(shan.Spouse);
            Assert.Equal("Shan", anga.Spouse.Name);
            Assert.Equal("Anga", shan.Spouse.Name);
        }

        [Fact]
        public void GivenAChild_WhenAddChildrenIsCalledUsingMotherName_ShouldReturnTrue()
        {
            var chit = new Person("Chit", Gender.Male, shan, anga);
            var status = anga.AddChildren(chit);
            Assert.True(status);
            Assert.NotNull(anga.Children);
            Assert.True(anga.Children.Count > 0);
            int count = anga.Children.Count;
            int foundAtIndex = 0;
            bool found = false;
            for (int i = 0; i < count; i++)
            {
                if (anga.Children[i].Name == "Chit")
                {
                    found = true;
                    foundAtIndex = i;
                }
            }
            if (found)
            {
                anga.Children.RemoveAt(foundAtIndex);
            }
            Assert.True(found);
        }

        [Fact]
        public void GivenChildNameAndGender_WhenAddChildrenIsCalledUsingMotherName_ShouldReturnTrue()
        {
            var status = anga.AddChildren("Ish", Gender.Male);
            Assert.True(status);
            Assert.NotNull(anga.Children);
            Assert.True(anga.Children.Count > 0);
            int count = anga.Children.Count;
            int foundAtIndex = 0;
            bool found = false;
            for (int i = 0; i < count; i++)
            {
                if (anga.Children[i].Name == "Ish")
                {
                    found = true;
                    foundAtIndex = i;
                }
            }
            if (found)
            {
                anga.Children.RemoveAt(foundAtIndex);
            }
            Assert.True(found);
        }

        [Fact]
        public void GivenChildNameAndGender_WhenAddChildrenIsCalledUsingFatherName_ShouldReturnFalse()
        {
            var status = shan.AddChildren("Ish", Gender.Male);
            Assert.False(status);
        }

        [Fact]
        public void GivenAChild_WhenAddChildrenIsCalledUsingFatherName_ShouldReturnFalse()
        {
            var chit = new Person("Chit", Gender.Male, shan, anga);
            var status = shan.AddChildren(chit);
            Assert.False(status);
        }

        [Fact]
        public void GivenAPersonHasBrothers_WhenGetBrothersIsCalled_ShouldReturnListOfBrothers()
        {
            var chit = new Person("Chit", Gender.Male, shan, anga);
            var ish = new Person("Ish", Gender.Male, shan, anga);
            anga.AddChildren(chit);
            anga.AddChildren(ish);
            var brothers = chit.Brothers();
            Assert.NotNull(brothers);
            Assert.True(brothers.Count == 1);
            Assert.Equal("Ish", brothers[0]);
            //Remove Chit and Ish
            anga.Children.RemoveAt(0);
            anga.Children.RemoveAt(0);
        }

        [Fact]
        public void GivenAPersonDoesNotHaveBrothers_WhenGetBrothersIsCalled_ShouldReturnEmptyList()
        {
            var brothers = shan.Brothers();
            Assert.NotNull(brothers);
            Assert.True(brothers.Count == 0);
        }

        [Fact]
        public void GivenAPersonHasSister_WhenGetSistersIsCalled_ShouldReturnListOfSisters()
        {
            var chita = new Person("Chita", Gender.Female, shan, anga);
            var isha = new Person("Isha", Gender.Female, shan, anga);
            anga.AddChildren(chita);
            anga.AddChildren(isha);
            var sisters = chita.Sisters();
            Assert.NotNull(sisters);
            Assert.True(sisters.Count == 1);
            Assert.Equal("Isha", sisters[0]);
            //Remove Chita and Isha
            anga.Children.RemoveAt(0);
            anga.Children.RemoveAt(0);
        }

        [Fact]
        public void GivenAPersonDoesNotHaveSister_WhenGetSistersIsCalled_ShouldReturnEmptyList()
        {
            var sisters = shan.Sisters();
            Assert.NotNull(sisters);
            Assert.True(sisters.Count == 0);
        }

        [Fact]
        public void GivenAPersonDoesNotHaveSon_WhenGetSonIsCalled_ShouldReturnEmptyList()
        {
            var son = shan.Son();
            Assert.NotNull(son);
            Assert.True(son.Count == 0);
        }

        [Fact]
        public void GivenAPersonDoesNotHaveDaughter_WhenGetDaughterIsCalled_ShouldReturnEmptyList()
        {
            var daughter = shan.Daughter();
            Assert.NotNull(daughter);
            Assert.True(daughter.Count == 0);
        }

        [Fact]
        public void GivenAPersonHasSon_WhenGetSonIsCalled_ShouldReturnListOfSon()
        {
            var ish = new Person("Ish", Gender.Male, shan, anga);
            anga.AddChildren(ish);
            var son = anga.Son();
            Assert.NotNull(son);
            Assert.True(son.Count == 1);
            Assert.Equal("Ish", son[0]);
            //Remove Ish
            anga.Children.RemoveAt(0);
        }

        [Fact]
        public void GivenAPersonHasDaughter_WhenGetDaughterIsCalled_ShouldReturnListOfDaughter()
        {
            var isha = new Person("Isha", Gender.Female, shan, anga);
            anga.AddChildren(isha);
            var daughter = anga.Daughter();
            Assert.NotNull(daughter);
            Assert.True(daughter.Count == 1);
            Assert.Equal("Isha", daughter[0]);
            //Remove Isha
            anga.Children.RemoveAt(0);
        }

        [Fact]
        public void GivenAPersonHasMarriedSiblings_WhenGetSiblingsHusbandsIsCalled_ReturnsList()
        {
            var satya = new Person("Satya", Gender.Female, shan, anga);
            var vyan = new Person("Vyan", Gender.Male, null, null);
            satya.AddSpouse(vyan);
            vyan.AddSpouse(satya);
            var chit = new Person("Chit", Gender.Male, shan, anga);
            anga.AddChildren(chit);
            anga.AddChildren(satya);
            var husbands = chit.SiblingHusbands();
            Assert.NotNull(husbands);
            Assert.True(husbands.Count == 1);
            Assert.Equal("Vyan", husbands[0]);
            //Remove Chit and Ish
            anga.Children.RemoveAt(0);
            anga.Children.RemoveAt(0);
        }   
        
        [Fact]
        public void GivenAPersonDoesNotHaveMarriedSiblings_WhenGetSiblingsHusbandsIsCalled_ReturnsEmptyList()
        {
            var chit = new Person("Chit", Gender.Male, shan, anga);
            var ish = new Person("Ish", Gender.Male, shan, anga);
            anga.AddChildren(chit);
            anga.AddChildren(ish);
            var husbands = ish.SiblingHusbands();
            Assert.NotNull(husbands);
            Assert.True(husbands.Count == 0);
            //Remove Chit and Ish
            anga.Children.RemoveAt(0);
            anga.Children.RemoveAt(0);
        }

        [Fact]
        public void GivenAPersonHasMarriedSiblings_WhenGetSiblingsWivesIsCalled_ReturnsList()
        {
            var chit = new Person("Chit", Gender.Male, shan, anga);
            var ish = new Person("Ish", Gender.Male, shan, anga);
            var amba = new Person("Amba", Gender.Female, null, null);
            chit.AddSpouse(amba);
            amba.AddSpouse(chit);
            anga.AddChildren(chit);
            anga.AddChildren(ish);
            var wives = ish.SiblingWives();
            Assert.NotNull(wives);
            Assert.True(wives.Count == 1);
            Assert.Equal("Amba", wives[0]);
            //Remove Chit and Ish
            anga.Children.RemoveAt(0);
            anga.Children.RemoveAt(0);
        }

        [Fact]
        public void GivenAPersonDoesNotHaveMarriedSiblings_WhenGetSiblingsWivesIsCalled_ReturnsEmptyList()
        {
            var chit = new Person("Chit", Gender.Male, shan, anga);
            var ish = new Person("Ish", Gender.Male, shan, anga);
            anga.AddChildren(chit);
            anga.AddChildren(ish);
            var wives = ish.SiblingWives();
            Assert.NotNull(wives);
            Assert.True(wives.Count == 0);
            //Remove Chit and Ish
            anga.Children.RemoveAt(0);
            anga.Children.RemoveAt(0);
        }
    }
}

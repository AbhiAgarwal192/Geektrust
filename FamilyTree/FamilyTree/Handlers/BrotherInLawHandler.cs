using FamilyTree.Entities;
using System.Collections.Generic;

namespace FamilyTree.Handlers
{
    public class BrotherInLawHandler : IProcess
    {
        public List<string> Process(Person person)
        {
            var brotherInLaws = new List<string>();

            if (person.IsMarried())
            {
                brotherInLaws = person.Spouse.Brothers();
            }

            var siblingshusbands = person.SiblingHusbands();

            Merge(siblingshusbands, brotherInLaws);

            return brotherInLaws;
        }

        private void Merge(List<string> list1, List<string> list2)
        {
            int count = list1.Count;
            for (int i = 0; i < count; i++)
            {
                list2.Add(list1[i]);
            }
        }
    }
}

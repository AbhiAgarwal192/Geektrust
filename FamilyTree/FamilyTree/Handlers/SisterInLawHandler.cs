using FamilyTree.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamilyTree.Handlers
{
    public class SisterInLawHandler : IProcess
    {
        public List<string> Process(Person person)
        {
            var sisterInLaws = new List<string>();

            if (person.IsMarried())
            {
                sisterInLaws = person.Spouse.Sisters();
            }

            var siblingswives = person.SiblingWives();

            Merge(siblingswives, sisterInLaws);

            return sisterInLaws;
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

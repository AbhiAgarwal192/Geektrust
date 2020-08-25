using FamilyTree.Entities;
using FamilyTree.Enums;
using System;
using System.Collections.Generic;

namespace FamilyTree.Handlers
{
    public class MaternalUncleHandler : IProcess
    {
        public List<string> Process(Person person)
        {
            var list = new List<string>();
            if (person.Mother == null)
            {
                return list;
            }
            list = person.Mother.Brothers();
            return list;
        }
    }
}

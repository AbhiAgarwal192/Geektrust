using FamilyTree.Entities;
using FamilyTree.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamilyTree.Handlers
{
    public class MaternalAuntHandler : IProcess
    {
        public List<string> Process(Person person)
        {
            var list = new List<string>();
            if (person.Mother == null)
            {
                return list;
            }
            list = person.Mother.Sisters();
            return list;
        }
    }
}

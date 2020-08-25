using FamilyTree.Constants;
using FamilyTree.Entities;
using FamilyTree.Enums;
using FamilyTree.Handlers;
using System.Collections.Generic;

namespace FamilyTree.Utilities
{
    public class Operation
    {
        private Kingdom _kingdom;
        private readonly string Female = "Female";
        private RelationshipHandler _relationshipHandler;
        public Operation(Kingdom kingdom)
        {
            this._kingdom = kingdom;
            this._relationshipHandler = new RelationshipHandler();
        }
        public string Perform(string[] args)
        {
            string output = "";
            var childToFind = args[1];
            var node = this._kingdom.FindChild(childToFind);
            if (node == null)
            {
                return Message.PersonNotFound;
            }
            var operation = args[0];
            switch (operation){
                case "ADD_CHILD":
                    var gender = args[3];
                    var childName = args[2];
                    var success = node.AddChildren(childName, gender.Equals(Female) ? Gender.Female : Gender.Male);
                    output = success ? Message.ChildAdditionSuccessful : Message.ChildAdditionFailed;
                    break;
                case "GET_RELATIONSHIP":
                    var handler = _relationshipHandler.GetHandler(args[2]);
                    if (handler != null)
                    {
                        var result = handler.Process(node);
                        output = ConvertToString(result);
                    }
                    break;
            }
            return output;
        }

        private string ConvertToString(List<string> list)
        {
            int count = list.Count;
            if (count == 0)
            {
                return Message.None;
            }
            string obj = "";
            for (int i = 0; i < count; i++)
            {
                obj = $"{obj} {list[i]}";
            }

            return obj.Trim();
        }
    }
}

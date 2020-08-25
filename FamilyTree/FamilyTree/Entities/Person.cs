using FamilyTree.Enums;
using System.Collections.Generic;

namespace FamilyTree.Entities
{
    public class Person
    {
        private string _name;
        private Gender _gender;
        private Person _father;
        private Person _mother;
        private Person _spouse;
        private List<Person> _children;
        public string Name { get { return _name; } }
        public Gender Gender { get { return _gender; } }
        public Person Father { get { return _father; } }
        public Person Mother { get { return _mother; } }
        public Person Spouse { get { return _spouse; } }
        public List<Person> Children { get { return _children; } }
        public Person(string name, Gender gender, Person father, Person mother)
        {
            this._name = name;
            this._gender = gender;
            this._father = father;
            this._mother = mother;
            this._children = new List<Person>();
        }
        public bool IsMarried()
        {
            if (this._spouse!=null)
            {
                return true;
            }
            return false;
        }
        public bool AddChildren(Person child)
        {
            if (this._gender == Gender.Male)
            {
                return false;
            }
            this._children.Add(child);
            return true;
        }
        public bool AddChildren(string name, Gender gender)
        {
            if (this._gender == Gender.Male)
            {
                return false;
            }
            var father = this.Gender == Gender.Male ? this : this.Spouse;
            var mother = this.Gender == Gender.Female ? this : this.Spouse;
            var child = new Person(name,gender,father,mother);
            this._children.Add(child);
            return true;
        }
        public void AddSpouse(Person spouse)
        {
            this._spouse = spouse;
        }
        public List<string> Brothers()
        {
            var list = new List<string>();
            if (this.Mother == null)
            {
                return list;
            }

            int count = this.Mother.Children.Count;
            for (int i=0;i<count;i++)
            {
                if (this.Mother.Children[i].Gender == Gender.Male && !this.Mother.Children[i].Name.Equals(this.Name))
                {
                    list.Add(this.Mother.Children[i].Name);
                }
            }

            return list;
        }
        public List<string> Sisters()
        {
            var list = new List<string>();
            if (this.Mother == null)
            {
                return list;
            }

            int count = this.Mother.Children.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.Mother.Children[i].Gender == Gender.Female && !this.Mother.Children[i].Name.Equals(this.Name))
                {
                    list.Add(this.Mother.Children[i].Name);
                }
            }

            return list;
        }
        public List<string> SiblingHusbands()
        {
            var list = new List<string>();
            if (this.Mother == null)
            {
                return list;
            }

            int count = this.Mother.Children.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.Mother.Children[i].Gender == Gender.Female && !this.Mother.Children[i].Name.Equals(this.Name))
                {
                    if (this.Mother.Children[i].IsMarried())
                    {
                        list.Add(this.Mother.Children[i].Spouse.Name);
                    }
                }
            }
            return list;
        }
        public List<string> SiblingWives()
        {
            var list = new List<string>();
            if (this.Mother == null)
            {
                return list;
            }

            int count = this.Mother.Children.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.Mother.Children[i].Gender == Gender.Male && !this.Mother.Children[i].Name.Equals(this.Name))
                {
                    if (this.Mother.Children[i].IsMarried())
                    {
                        list.Add(this.Mother.Children[i].Spouse.Name);
                    }
                }
            }
            return list;
        }
        public List<string> Daughter()
        {
            var list = new List<string>();
            int count = this.Children.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.Children[i].Gender == Gender.Female)
                {
                    list.Add(this.Children[i].Name);
                }
            }
            return list;
        }
        public List<string> Son()
        {
            var list = new List<string>();
            int count = this.Children.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.Children[i].Gender == Gender.Male)
                {
                    list.Add(this.Children[i].Name);
                }
            }
            return list;
        }
    }

}

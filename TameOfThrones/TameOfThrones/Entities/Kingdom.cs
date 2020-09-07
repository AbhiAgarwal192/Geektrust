using System;
using System.Collections.Generic;

namespace TameOfThrones.Entities
{
    public class Kingdom
    {
        private string _name;
        private string _emblem;
        private List<Kingdom> _allies;
        private Message _message;
        public Kingdom(string name,string emblem)
        {
            this._name = name;
            this._emblem = emblem.ToUpper();
            this._allies = new List<Kingdom>();
            this._message = new Message();
        }
        public string Name { get { return this._name; } }
        public string Emblem { get { return this._emblem; } }
        public void SendMessage(Kingdom kingdom , string message)
        {
            if (kingdom!=null && !this._allies.Contains(kingdom) && kingdom.IsAlly(message))
            {
                this._allies.Add(kingdom);
            }
        }
        public bool IsAlly(string message)
        {
            return this._message.Verify(message,this._emblem);
        }
        public List<Kingdom> Allies
        {
            get
            {
                return this._allies;
            }
        }
    }
}

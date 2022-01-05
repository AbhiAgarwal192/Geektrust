using System.Collections.Generic;

namespace TheLedger.Entities
{
    public class Bank
    {
        private string _name;
        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public List<Borrower> Borrowers;
        public Bank(string name,List<Borrower> borrowers = null)
        {
            this._name = name;
            Borrowers = (borrowers == null) ? new List<Borrower>() : borrowers;
        }

    }
}

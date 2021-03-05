using System;
using System.Collections.Generic;
using System.Text;

namespace War.Entities
{
    public class Army
    {
        private int _horses;
        private int _elephants;
        private int _tanks;
        private int _guns;
        public int Horses
        {
            get
            {
                return this._horses;
            }
        }
        public int Elephants
        {
            get
            {
                return this._elephants;
            }
        }
        public int Tanks
        {
            get
            {
                return this._tanks;
            }
        }
        public int Guns
        {
            get
            {
                return this._guns;
            }
        }
        public Army(int horses,int elephants,int tanks,int guns)
        {
            this._horses = horses;
            this._elephants = elephants;
            this._tanks = tanks;
            this._guns = guns;
        }
    }
}

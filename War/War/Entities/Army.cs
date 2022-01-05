using System.Collections.Generic;

namespace War.Entities
{
    public class Army
    {
        public List<Battalion> Battalions;
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
            set
            {
                this._horses = value;
            }
        }
        public int Elephants
        {
            get
            {
                return this._elephants;
            }
            set
            {
                this._elephants = value;
            }
        }
        public int Tanks
        {
            get
            {
                return this._tanks;
            }
            set
            {
                this._tanks = value;
            }
        }
        public int Guns
        {
            get
            {
                return this._guns;
            }
            set
            {
                this._guns = value;
            }
        }
        public Army(int horses,int elephants,int tanks,int guns)
        {
            this._horses = horses;
            this._elephants = elephants;
            this._tanks = tanks;
            this._guns = guns;

            this.Battalions.Add(new Battalion { Type = Constants.BattalionType.HORSE, Unit = horses});
            this.Battalions.Add(new Battalion { Type = Constants.BattalionType.ELEPHANTS, Unit = elephants });
            this.Battalions.Add(new Battalion { Type = Constants.BattalionType.TANKS, Unit = tanks });
            this.Battalions.Add(new Battalion { Type = Constants.BattalionType.GUNS, Unit = guns });

        }
    }
}

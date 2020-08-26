namespace Traffic.Entities
{
    public class Orbit
    {
        private string _name;
        private int _length;
        private int _craters;
        public int Length
        {
            get
            {
                return this._length;
            }
        }
        public int Craters
        {
            get
            {
                return this._craters;
            }
        }
        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public Orbit(int length,int craters, string name)
        {
            this._length = length;
            this._craters = craters;
            this._name = name;
        }
    }
}

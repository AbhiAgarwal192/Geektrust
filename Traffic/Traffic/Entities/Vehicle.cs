using Traffic.Constants;

namespace Traffic.Entities
{
    public class Vehicle
    {
        private int _speed;
        private int _timePerCrater;
        private VehicleType _type;
        public int Speed
        {
            get
            {
                return this._speed;
            }
        }
        public int TimePerCrater
        {
            get
            {
                return this._timePerCrater;
            }
        }
        public VehicleType Type
        {
            get
            {
                return this._type;
            }
        }
        public Vehicle(int speed, int time, VehicleType type)
        {
            this._speed = speed;
            this._timePerCrater = time;
            this._type = type;
        }
    }
}

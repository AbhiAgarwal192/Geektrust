namespace Traffic.Entities
{
    public class Vehicle
    {
        public int Speed;
        public int TimePerCrater;
        public VehicleType VehicleType;
        public Vehicle(int speed, int time, VehicleType type)
        {
            this.Speed = speed;
            this.TimePerCrater = time;
            this.VehicleType = type;
        }
    }
}

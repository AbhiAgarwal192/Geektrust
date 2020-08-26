using Traffic.Entities;

namespace Traffic
{
    public class KingShan
    {
        private Calculator _calculator;
        public KingShan()
        {
            this._calculator = new Calculator();
        }

        public string DecideVehicle(string weatherConditions, double orbitOneSpeed, double orbitTwoSpeed)
        {
            var orbit = this._calculator.FastestRouteToReachDestination(weatherConditions,orbitOneSpeed,orbitTwoSpeed,out Vehicle vehicle);
            string vehicleType = "TUKTUK";
            if (vehicle.VehicleType == VehicleType.Bike)
                vehicleType = "BIKE";
            else if (vehicle.VehicleType == VehicleType.Car)
                vehicleType = "CAR";
            string output = $"{vehicleType} {orbit.Name}";
            return output;
        }
    }
}

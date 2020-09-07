using Traffic.Entities;
using Traffic.Constants;

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
            if (vehicle.Type == VehicleType.Bike)
                vehicleType = "BIKE";
            else if (vehicle.Type == VehicleType.Car)
                vehicleType = "CAR";
            return $"{vehicleType} {orbit.Name}";
        }
    }
}

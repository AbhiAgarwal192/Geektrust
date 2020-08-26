using System.Collections.Generic;

namespace Traffic.Entities
{
    public class Weather
    {
        public string WeatherConditions;
        public double AffectsCratersBy;
        public List<Vehicle> UsableVehicles;
        public Weather(string weatherConditions, double affectsCratersBy)
        {
            this.WeatherConditions = weatherConditions;
            this.AffectsCratersBy = affectsCratersBy;
            this.UsableVehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            this.UsableVehicles.Add(vehicle);
        }
    }
}

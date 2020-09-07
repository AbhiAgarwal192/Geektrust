using System.Collections.Generic;

namespace Traffic.Entities
{
    public class Weather
    {
        private string _weatherConditions;
        public double _affectsCratersBy;
        public List<Vehicle> UsableVehicles;
        public Weather(string weatherConditions, double affectsCratersBy)
        {
            this._weatherConditions = weatherConditions;
            this._affectsCratersBy = affectsCratersBy;
            this.UsableVehicles = new List<Vehicle>();
        }

        public string WeatherConditions
        {
            get
            {
                return _weatherConditions;
            }
        }

        public double AffectsCratersBy
        {
            get
            {
                return _affectsCratersBy;
            }
        }

        public void AddVehicle(Vehicle vehicle)
        {
            this.UsableVehicles.Add(vehicle);
        }
    }
}

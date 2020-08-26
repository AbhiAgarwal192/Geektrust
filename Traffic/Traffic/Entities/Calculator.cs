using System;
using System.Collections.Generic;

namespace Traffic.Entities
{
    public class Calculator
    {
        private Weather sunny;
        private Weather rainy;
        private Weather windy;
        private Orbit orbitOne;
        private Orbit orbitTwo;
        public Calculator()
        {
            var car = new Vehicle(20,3,VehicleType.Car);
            var bike = new Vehicle(10,2,VehicleType.Bike);
            var tuktuk = new Vehicle(12,1,VehicleType.TukTuk);
            this.sunny = new Weather(WeatherConditions.WINDY, -0.1);
            this.sunny.AddVehicle(car);
            this.sunny.AddVehicle(bike);
            this.sunny.AddVehicle(tuktuk);
            this.rainy = new Weather(WeatherConditions.RAINY, 0.2);
            this.rainy.AddVehicle(car);
            this.rainy.AddVehicle(tuktuk);
            this.windy = new Weather(WeatherConditions.WINDY, 0);
            this.windy.AddVehicle(car);
            this.windy.AddVehicle(bike);
            this.orbitTwo = new Orbit(20, 10,"ORBIT2");
            this.orbitOne = new Orbit(18, 20, "ORBIT1");
        }

        public Orbit FastestRouteToReachDestination(string weatherConditions, double orbitOneSpeed, double orbitTwoSpeed, out Vehicle vehicle)
        {
            vehicle = null;
            double time1 = TimeTakenToReachDestination(weatherConditions,orbitOne,orbitOneSpeed,out Vehicle vehicle1);
            double time2 = TimeTakenToReachDestination(weatherConditions, orbitTwo, orbitTwoSpeed, out Vehicle vehicle2);

            if (time1<time2)
            {
                vehicle = vehicle1;
                return this.orbitOne;
            }
            else if (time2<time1)
            {
                vehicle = vehicle2;
                return this.orbitTwo;
            }

            vehicle = Select(vehicle1, vehicle2);
            return vehicle == vehicle1 ? orbitOne : orbitTwo;
        }
        public double TimeTakenToReachDestination(string weatherConditions, Orbit orbit, double speed, out Vehicle vehicle)
        {
            double time = Double.MaxValue;
            vehicle = null;
            double newCrater = 0;
            var usableVehicleList = new List<Vehicle>();
            switch (weatherConditions)
            {
                case WeatherConditions.RAINY:
                    newCrater = orbit.Craters + rainy.AffectsCratersBy * orbit.Craters;
                    usableVehicleList = rainy.UsableVehicles;
                    break;
                case WeatherConditions.WINDY:
                    newCrater = orbit.Craters + windy.AffectsCratersBy * orbit.Craters;
                    usableVehicleList = windy.UsableVehicles;
                    break;
                case WeatherConditions.SUNNY:
                    newCrater = orbit.Craters + sunny.AffectsCratersBy * orbit.Craters;
                    usableVehicleList = sunny.UsableVehicles;
                    break;
                default:
                    break;
            }
            int count = usableVehicleList.Count;
            for (int i = 0; i < count; i++)
            {
                var possibleSpeed = Math.Min(speed, usableVehicleList[i].Speed);
                var timeTakenToCrossCraters = newCrater * usableVehicleList[i].TimePerCrater;
                //Total Time in minutes
                var totalTime = timeTakenToCrossCraters + (orbit.Length / possibleSpeed) * 60;
                if (totalTime < time)
                {
                    time = totalTime;
                    vehicle = usableVehicleList[i];
                }
                else if (totalTime == time)
                {
                    vehicle = Select(vehicle, usableVehicleList[i]);
                }
            }
            return time;
        }

        private Vehicle Select(Vehicle selectedVehicle, Vehicle newVehicle)
        {
            if (selectedVehicle.VehicleType < newVehicle.VehicleType)
            {
                return selectedVehicle;                
            }
            else 
            {
                return newVehicle;
            }
        }
    }
}

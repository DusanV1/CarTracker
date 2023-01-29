using System;
namespace ServiceCarTracker
{
	public class Fuel
	{
        //public DateTime FuelDate { get; set; }
        public string FuelDate { get; set; }
        public double FuelAmount { get; set; }
        public double FuelPriceTotal { get; set; }
        public double FuelPricePerLiter { get; set; }
        public double FuelCarMilage { get; set; }
        public double FuelConsumption { get; set; }
        public double FuelPricePerKm { get; set; }
        public string FuelGasStation { get; set; }

        public Fuel()
		{
		}

        public Fuel(string fuelDate,
            double fuelAmount,
            double fuelPriceTotal,
            double fuelPricePerLiter,
            double fuelCarMilage,
            double fuelConsumption,
            double fuelPricePerKm,
            string fuelGasStation)
        {
            FuelDate = fuelDate;
            FuelAmount = fuelAmount;
            FuelPriceTotal = fuelPriceTotal;
            FuelPricePerLiter = fuelPricePerLiter;
            FuelCarMilage = fuelCarMilage;
            FuelConsumption = fuelConsumption;
            FuelPricePerKm = fuelPricePerKm;
            FuelGasStation = fuelGasStation;
            
        }
    }
}


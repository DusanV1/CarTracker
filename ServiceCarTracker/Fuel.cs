using System;
namespace ServiceCarTracker
{
	public class Fuel
	{
		public DateTime FuelDate { get; set; }
        public double FuelAmount { get; set; }
        public double TotalPrice { get; set; }
        public double PricePerLiter { get; set; }
        public double CarMilage { get; set; }
        public double FuelConsumption { get; set; }
        public double PricePerKm { get; set; }
        public string GasStation { get; set; }

        public Fuel()
		{
		}
	}
}


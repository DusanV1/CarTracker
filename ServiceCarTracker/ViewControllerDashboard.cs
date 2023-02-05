// This file has been autogenerated from a class added in the UI designer.

using System;

using System.Linq;
using Foundation;
using AppKit;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ServiceCarTracker
{
	public partial class ViewControllerDashboard : NSViewController
	{
		public ViewControllerDashboard (IntPtr handle) : base (handle)
		{
        }

		public override void ViewDidAppear()
		{
            List<double> data = new List<double>();
			data=CalcDataFuel(ViewControllerFuel.DataSource);

            TextInpAvgConsumptionDash(Convert.ToString(Math.Round(data[0],1)));
            TextInpAvgPricePerKmDash(Convert.ToString(Math.Round(data[1],2)));
            TextInpTotalPriceFuelDash(Convert.ToString(data[2]));

        }

        //Copy data not just reference them (because of the average it is necessary to delete last line with zeroes
        public static FuelTableDataSource DeepCopyFuel(FuelTableDataSource dataSource)
        {
            FuelTableDataSource result = new FuelTableDataSource();
            foreach (var item in dataSource.Fuels)
            {
                result.Fuels.Add(new Fuel
                {
                    FuelDate = item.FuelDate,
                    FuelAmount = item.FuelAmount,
                    FuelPriceTotal=item.FuelPriceTotal,
                    FuelPricePerLiter=item.FuelPricePerLiter,
                    FuelCarMilage=item.FuelCarMilage,
                    FuelConsumption=item.FuelConsumption,
                    FuelPricePerKm=item.FuelPricePerKm,
                    FuelGasStation=item.FuelGasStation
                });
            }

            return result;
        }

        public List<double> CalcDataFuel(FuelTableDataSource dataSource)
		{
			List<double> result=new List<double>();
			FuelTableDataSource data = new FuelTableDataSource();
			data = DeepCopyFuel(dataSource);
            
            data.Fuels.RemoveAt(dataSource.Fuels.Count-1);
            result.Add(data.Fuels.Average(x => x.FuelConsumption));
            result.Add(data.Fuels.Average(x => x.FuelPricePerKm));
            result.Add(data.Fuels.Sum(x => x.FuelPriceTotal));

            return result;
		}

        private void TextInpAvgConsumptionDash(string value)
        {
            AvgConsumptionDash.StringValue = value;
        }

        private void TextInpAvgPricePerKmDash(string value)
        {
            AvgPricePerKmDash.StringValue = value;
        }

        private void TextInpTotalPriceFuelDash(string value)
        {
            TotalPriceFuelDash.StringValue = value;
        }
    }
}

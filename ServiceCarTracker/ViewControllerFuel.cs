// This file has been autogenerated from a class added in the UI designer.

using System;

using System.IO;
using Foundation;
using AppKit;
using StoreKit;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ServiceCarTracker
{
	public partial class ViewControllerFuel : NSViewController
	{
		public ViewControllerFuel (IntPtr handle) : base (handle)
		{
		}

        //public FuelTableDataSource DataSourceWhole = new FuelTableDataSource();
        public static FuelTableDataSource DataSource = new FuelTableDataSource();
        public int i = 0;

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            // Create the Product Table Data Source and populate it
            //var DataSource = new FuelTableDataSource();

            //It loads twice for some reason
            if(i==0)
            {
                //DataSource.Fuels.Add(new Fuel("10/15/2022", 40.63,
                //1661.8, 40.9, 230623,
                //6.7, 2.75, "Tank Ono"));

                //DataSource.Fuels.Add(new Fuel("10/24/2022", 44.46,
                //1818.4, 40.9, 231288,
                //6.69, 2.73, "Tank Ono"));

                DataSource.Fuels.Add(new Fuel("-", 0,
                0, 0, 0,
                0, 0, "-"));

                

                //DataSourceWhole = DataSource;

                // Populate the Product Table
                PopulateTableFuels(DataSource);
                //FuelTable.DataSource = DataSource;
                //FuelTable.Delegate = new FuelTableDelegate(DataSource);
            }

            i++;
        }

        private string GetTextDateFuel()
        {
            //check if it is blank -> show warning and let the user input the parameter again
            return TxtFldDateFuel.StringValue;
        }
        private string GetTextAmountFuel()
        {
            return TxtFldAmountFuel.StringValue;
        }
        private string GetTextCarMilageFuel()
        {
            return TxtFldCarMilageFuel.StringValue;
        }
        private string GetTextGasStationFuel()
        {
            return TxtFldGasStationFuel.StringValue;
        }
        private string GetTextPriceTotalFuel()
        {
            return TxtFldPriceTotalFuel.StringValue;
        }
        private string GetTextCarMilageFuelPrevious()
        {
            return TxtFldCarMilageFuel.StringValue;
        }
        private void ResetTxtFlds()
        {
            TxtFldDateFuel.StringValue = "";
            TxtFldAmountFuel.StringValue = "";
            TxtFldCarMilageFuel.StringValue = "";
            TxtFldGasStationFuel.StringValue = "";
            TxtFldPriceTotalFuel.StringValue = "";
        }
        public void ReloadTable()
        {
            FuelTable.ReloadData();
        }
        public void PopulateTableFuels(FuelTableDataSource dataSource)
        {
            // Populate the Product Table
            FuelTable.DataSource = dataSource;
            FuelTable.Delegate = new FuelTableDelegate(dataSource);
            ReloadTable();
        }

        public static void JsonStorage(List<Fuel> fuels, string location)
        {
            string jsonString = JsonSerializer.Serialize(fuels);
            //string location = "/Users/dusan/My_data/obecne/CSharp/JsonTest/TestJsonFile.json";
            File.WriteAllText(location, jsonString);
        }

        public static List<Fuel> JsonRead(string location)
        {
            string jsonString = File.ReadAllText(location);
            //Fuel fuelObject = JsonSerializer.Deserialize<Fuel>(jsonString)!;
            var fuelObjects = JsonSerializer.Deserialize<List<Fuel>>(jsonString);
            return fuelObjects;
        }




        partial void BtnUpdateTableFuel(NSButton sender)
        {
            //PopulateTableFuels(DataSourceWhole);
            PopulateTableFuels(DataSource);
            //ReloadTable();
        }

        partial void BtnDeleteRowFuel(NSButton sender)
        {
            //delete selected line
            nint row = FuelTable.SelectedRow;
            DataSource.Fuels.RemoveAt(Convert.ToInt32(row));
            ReloadTable();
        }

        partial void BtnInsertDataFuel(NSButton sender)
        {
            //var DataSource = new FuelTableDataSource();
            //DataSource.Products.Add(new Product(GetTextColumn1(), GetTextColumn2(), GetTextColumn3()));
            //DataSource = DataSourceWhole;
            //DataSource.Products.Add(new Product(GetTextColumn1(), GetTextColumn2(), GetTextColumn3()));

            //calculate the rest of the values
            double amountFuel = Convert.ToDouble(GetTextAmountFuel());
            double carMilageFuel = Convert.ToDouble(GetTextCarMilageFuel());
            double priceTotalFuel = Convert.ToDouble(GetTextPriceTotalFuel());
            Fuel DataFuel = DataSource.Fuels[0];
            double carMilageFuelPrevious = DataFuel.FuelCarMilage;
            double pricePerLiterFuel = Math.Round(priceTotalFuel / amountFuel,2);
            double consumptionFuel = Math.Round(amountFuel / ((carMilageFuel - carMilageFuelPrevious) / 100),1);
            double pricePerKmFuel = Math.Round(pricePerLiterFuel / (100 / consumptionFuel),2);
            
            DataSource.Fuels.Insert(0, (new Fuel(GetTextDateFuel(), amountFuel,
                priceTotalFuel, pricePerLiterFuel, carMilageFuel,
                consumptionFuel, pricePerKmFuel, GetTextGasStationFuel())));

            // Populate the Product Table
            PopulateTableFuels(DataSource);
            //FuelTable.DataSource = DataSource;
            //FuelTable.Delegate = new FuelTableDelegate(DataSource);
            ////FuelTable.ReloadData();
            //ReloadTable();

            //DataSourceWhole = DataSource;
            ResetTxtFlds();
            
        }
    }
}

using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;

namespace ServiceCarTracker
{
	public class FuelTableDelegate : NSTableViewDelegate
    {

        #region Constants 
        private const string CellIdentifier = "FuelCell";
        #endregion

        #region Private Variables
        private FuelTableDataSource DataSource;
        #endregion

        #region Constructors
        public FuelTableDelegate(FuelTableDataSource dataSource)
        {
            DataSource = dataSource;
        }
        #endregion

        public bool IsDouble(string text)
        {
            Double num = 0;
            bool isDouble = false;

            // Check for empty string.
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            isDouble = Double.TryParse(text, out num);

            return isDouble;
        }

        #region Override Methods
        //cannot modify data in the table
        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            // This pattern allows you reuse existing views when they are no-longer in use.
            // If the returned view is null, you instance up a new view
            // If a non-null view is returned, you modify it enough to reflect the new data
            NSTextField view = (NSTextField)tableView.MakeView(tableColumn.Title, this);
            if (view == null)
            {
                view = new NSTextField();
                //view.Identifier = CellIdentifier;
                view.Identifier = tableColumn.Title;
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Selectable = false;
                view.Editable = true;
            }

            view.EditingEnded += (sender, e) => {

                // Take action based on type
                if(DataSource.Fuels.Count>1)
                {
                    switch (view.Identifier)
                    {
                        case "Date":
                            DataSource.Fuels[(int)view.Tag].FuelDate = view.StringValue;
                            break;

                        case "Amount":
                            //DataSource.Products[(int)view.Tag].Column2 = view.StringValue;
                            //break;
                            if (IsDouble(view.StringValue))
                            {
                                DataSource.Fuels[(int)view.Tag].FuelAmount = Convert.ToDouble(view.StringValue);
                                DataSource.Fuels[(int)view.Tag].FuelPricePerLiter = Math.Round(DataSource.Fuels[(int)view.Tag].FuelPriceTotal / DataSource.Fuels[(int)view.Tag].FuelAmount,2);
                                DataSource.Fuels[(int)view.Tag].FuelConsumption = Math.Round(DataSource.Fuels[(int)view.Tag].FuelAmount / ((DataSource.Fuels[(int)view.Tag].FuelCarMilage - DataSource.Fuels[(int)view.Tag + 1].FuelCarMilage) / 100),1);
                                DataSource.Fuels[(int)view.Tag].FuelPricePerKm = Math.Round(DataSource.Fuels[(int)view.Tag].FuelPricePerLiter / (100 / DataSource.Fuels[(int)view.Tag].FuelConsumption),2);

                                //write data to different cell or update whole table or row

                                //tableColumn.Title = "PricePerLiter";
                                //NSTextField viewFuelPricePerLiter = (NSTextField)tableView.MakeView(tableColumn.Title, this);
                                //viewFuelPricePerLiter.Identifier= "PricePerLiter";
                                //viewFuelPricePerLiter.StringValue = Convert.ToString(DataSource.Fuels[(int)view.Tag].FuelPricePerLiter);

                                //ViewControllerFuel().ReloadTable();
                                //FuelTable.DataSource = dataSource;
                                //FuelTable.Delegate = new FuelTableDelegate(dataSource);
                                //FuelTable.ReloadData();
                                //ReloadTable();

                                break;
                            }
                            else
                            {
                                view.StringValue = Convert.ToString(DataSource.Fuels[(int)view.Tag].FuelAmount);
                                break;
                            }
                        case "CarMilage":
                            //DataSource.Products[(int)view.Tag].Column2 = view.StringValue;
                            //break;
                            if (IsDouble(view.StringValue))
                            {
                                DataSource.Fuels[(int)view.Tag].FuelCarMilage = Convert.ToDouble(view.StringValue);
                                DataSource.Fuels[(int)view.Tag].FuelPricePerLiter = Math.Round(DataSource.Fuels[(int)view.Tag].FuelPriceTotal / DataSource.Fuels[(int)view.Tag].FuelAmount,2);
                                DataSource.Fuels[(int)view.Tag].FuelConsumption = Math.Round(DataSource.Fuels[(int)view.Tag].FuelAmount / ((DataSource.Fuels[(int)view.Tag].FuelCarMilage - DataSource.Fuels[(int)view.Tag + 1].FuelCarMilage) / 100),1);
                                DataSource.Fuels[(int)view.Tag].FuelPricePerKm = Math.Round(DataSource.Fuels[(int)view.Tag].FuelPricePerLiter / (100 / DataSource.Fuels[(int)view.Tag].FuelConsumption),2);
                                break;
                            }
                            else
                            {
                                view.StringValue = Convert.ToString(DataSource.Fuels[(int)view.Tag].FuelCarMilage);
                                break;
                            }

                        case "GasStation":
                            DataSource.Fuels[(int)view.Tag].FuelGasStation = view.StringValue;
                            break;
                        case "PriceTotal":
                            //DataSource.Products[(int)view.Tag].Column2 = view.StringValue;
                            //break;
                            if (IsDouble(view.StringValue))
                            {
                                DataSource.Fuels[(int)view.Tag].FuelPriceTotal = Convert.ToDouble(view.StringValue);
                                DataSource.Fuels[(int)view.Tag].FuelPricePerLiter = Math.Round(DataSource.Fuels[(int)view.Tag].FuelPriceTotal / DataSource.Fuels[(int)view.Tag].FuelAmount,2);
                                DataSource.Fuels[(int)view.Tag].FuelConsumption = Math.Round(DataSource.Fuels[(int)view.Tag].FuelAmount / ((DataSource.Fuels[(int)view.Tag].FuelCarMilage - DataSource.Fuels[(int)view.Tag + 1].FuelCarMilage) / 100),1);
                                DataSource.Fuels[(int)view.Tag].FuelPricePerKm = Math.Round(DataSource.Fuels[(int)view.Tag].FuelPricePerLiter / (100 / DataSource.Fuels[(int)view.Tag].FuelConsumption),2);

                                break;
                            }
                            else
                            {
                                view.StringValue = Convert.ToString(DataSource.Fuels[(int)view.Tag].FuelPriceTotal);
                                break;
                            }
                            //case "PricePerKm":
                            //    //DataSource.Products[(int)view.Tag].Column2 = view.StringValue;
                            //    //break;
                            //    if (IsDouble(view.StringValue))
                            //    {
                            //        DataSource.Fuels[(int)view.Tag].FuelPricePerKm = Convert.ToDouble(view.StringValue);
                            //        break;
                            //    }
                            //    else
                            //    {
                            //        view.StringValue = Convert.ToString(DataSource.Fuels[(int)view.Tag].FuelPricePerKm);
                            //        break;
                            //    }
                            //case "PricePerLiter":
                            //    //DataSource.Products[(int)view.Tag].Column2 = view.StringValue;
                            //    //break;
                            //    if (IsDouble(view.StringValue))
                            //    {
                            //        DataSource.Fuels[(int)view.Tag].FuelPricePerLiter = Convert.ToDouble(view.StringValue);
                            //        break;
                            //    }
                            //    else
                            //    {
                            //        view.StringValue = Convert.ToString(DataSource.Fuels[(int)view.Tag].FuelPricePerLiter);
                            //        break;
                            //    }
                            //case "Consumption":
                            //    view.StringValue = Convert.ToString(DataSource.Fuels[(int)view.Tag].FuelConsumption);
                            //    break;
                            //if (IsDouble(view.StringValue))
                            //{
                            //    DataSource.Fuels[(int)view.Tag].FuelConsumption = Convert.ToDouble(view.StringValue);
                            //    break;
                            //}
                            //else
                            //{
                            //    view.StringValue = Convert.ToString(DataSource.Fuels[(int)view.Tag].FuelConsumption);
                            //    break;
                            //}




                    }
                }
                
            };
        

            // Tag view
            view.Tag = row;

            // Setup view based on the column selected
            switch (tableColumn.Title)
            {
                case "Date":
                    view.StringValue = DataSource.Fuels[(int)row].FuelDate;
                    break;
                case "Amount":
                    view.StringValue = Convert.ToString(DataSource.Fuels[(int)row].FuelAmount);
                    break;
                case "CarMilage":
                    view.StringValue = Convert.ToString(DataSource.Fuels[(int)row].FuelCarMilage);
                    break;
                case "Consumption":
                    view.StringValue = Convert.ToString(DataSource.Fuels[(int)row].FuelConsumption);
                    break;
                case "GasStation":
                    view.StringValue = DataSource.Fuels[(int)row].FuelGasStation;
                    break;
                case "PricePerKm":
                    view.StringValue = Convert.ToString(DataSource.Fuels[(int)row].FuelPricePerKm);
                    break;
                case "PricePerLiter":
                    view.StringValue = Convert.ToString(DataSource.Fuels[(int)row].FuelPricePerLiter);
                    break;
                case "PriceTotal":
                    view.StringValue = Convert.ToString(DataSource.Fuels[(int)row].FuelPriceTotal);
                    break;
            }

            return view;
        }
        #endregion



        //#region Override Methods
        ////cannot modify data in the table
        //public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        //{
        //    // This pattern allows you reuse existing views when they are no-longer in use.
        //    // If the returned view is null, you instance up a new view
        //    // If a non-null view is returned, you modify it enough to reflect the new data
        //    NSTextField view = (NSTextField)tableView.MakeView(CellIdentifier, this);
        //    if (view == null)
        //    {
        //        view = new NSTextField();
        //        view.Identifier = CellIdentifier;
        //        view.BackgroundColor = NSColor.Clear;
        //        view.Bordered = false;
        //        view.Selectable = false;
        //        view.Editable = false;
        //    }

        //    // Setup view based on the column selected
        //    switch (tableColumn.Title)
        //    {
        //        case "Date":
        //            view.StringValue = DataSource.Fuels[(int)row].FuelDate;
        //            break;
        //        case "Amount":
        //            view.StringValue = Convert.ToString(DataSource.Fuels[(int)row].FuelAmount);
        //            break;
        //        case "CarMilage":
        //            view.StringValue = Convert.ToString(DataSource.Fuels[(int)row].FuelCarMilage);
        //            break;
        //        case "Consumption":
        //            view.StringValue = Convert.ToString(DataSource.Fuels[(int)row].FuelConsumption);
        //            break;
        //        case "GasStation":
        //            view.StringValue = DataSource.Fuels[(int)row].FuelGasStation;
        //            break;
        //        case "PricePerKm":
        //            view.StringValue = Convert.ToString(DataSource.Fuels[(int)row].FuelPricePerKm);
        //            break;
        //        case "PricePerLiter":
        //            view.StringValue = Convert.ToString(DataSource.Fuels[(int)row].FuelPricePerLiter);
        //            break;
        //        case "PriceTotal":
        //            view.StringValue = Convert.ToString(DataSource.Fuels[(int)row].FuelPriceTotal);
        //            break;
        //    }

        //    return view;
        //}
        //#endregion




    }
}


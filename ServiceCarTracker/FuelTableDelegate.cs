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

        //check if the string in the text field is double
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

            //Table modification
            view.EditingEnded += (sender, e) =>
            {

                // if the modification is not on the last line 
                if (view.Tag + 1 != DataSource.Fuels.Count)
                {
                    switch (view.Identifier)
                    {
                        case "Date":
                            DataSource.Fuels[(int)view.Tag].FuelDate = view.StringValue;
                            break;

                        case "Amount":
                            if (IsDouble(view.StringValue))
                            {
                                DataSource.Fuels[(int)view.Tag].FuelAmount = Convert.ToDouble(view.StringValue);
                                DataSource.Fuels[(int)view.Tag].FuelPricePerLiter = Math.Round(DataSource.Fuels[(int)view.Tag].FuelPriceTotal / DataSource.Fuels[(int)view.Tag].FuelAmount, 2);
                                DataSource.Fuels[(int)view.Tag].FuelConsumption = Math.Round(DataSource.Fuels[(int)view.Tag].FuelAmount / ((DataSource.Fuels[(int)view.Tag].FuelCarMilage - DataSource.Fuels[(int)view.Tag + 1].FuelCarMilage) / 100), 1);
                                DataSource.Fuels[(int)view.Tag].FuelPricePerKm = Math.Round(DataSource.Fuels[(int)view.Tag].FuelPricePerLiter / (100 / DataSource.Fuels[(int)view.Tag].FuelConsumption), 2);
                                break;
                            }
                            else
                            {
                                view.StringValue = Convert.ToString(DataSource.Fuels[(int)view.Tag].FuelAmount);
                                break;
                            }
                        case "CarMilage":
                            if (IsDouble(view.StringValue))
                            {
                                if (view.Tag == 0)
                                {
                                    DataSource.Fuels[(int)view.Tag].FuelCarMilage = Convert.ToDouble(view.StringValue);
                                    DataSource.Fuels[(int)view.Tag].FuelPricePerLiter = Math.Round(DataSource.Fuels[(int)view.Tag].FuelPriceTotal / DataSource.Fuels[(int)view.Tag].FuelAmount, 2);
                                    DataSource.Fuels[(int)view.Tag].FuelConsumption = Math.Round(DataSource.Fuels[(int)view.Tag].FuelAmount / ((DataSource.Fuels[(int)view.Tag].FuelCarMilage - DataSource.Fuels[(int)view.Tag + 1].FuelCarMilage) / 100), 1);
                                    DataSource.Fuels[(int)view.Tag].FuelPricePerKm = Math.Round(DataSource.Fuels[(int)view.Tag].FuelPricePerLiter / (100 / DataSource.Fuels[(int)view.Tag].FuelConsumption), 2);
                                    break;
                                }else
                                {
                                    //change value and recalculate data on given line
                                    DataSource.Fuels[(int)view.Tag].FuelCarMilage = Convert.ToDouble(view.StringValue);
                                    DataSource.Fuels[(int)view.Tag].FuelPricePerLiter = Math.Round(DataSource.Fuels[(int)view.Tag].FuelPriceTotal / DataSource.Fuels[(int)view.Tag].FuelAmount, 2);
                                    DataSource.Fuels[(int)view.Tag].FuelConsumption = Math.Round(DataSource.Fuels[(int)view.Tag].FuelAmount / ((DataSource.Fuels[(int)view.Tag].FuelCarMilage - DataSource.Fuels[(int)view.Tag + 1].FuelCarMilage) / 100), 1);
                                    DataSource.Fuels[(int)view.Tag].FuelPricePerKm = Math.Round(DataSource.Fuels[(int)view.Tag].FuelPricePerLiter / (100 / DataSource.Fuels[(int)view.Tag].FuelConsumption), 2);
                                    //recalculate data in the line above
                                    DataSource.Fuels[(int)view.Tag - 1].FuelConsumption = Math.Round(DataSource.Fuels[(int)view.Tag - 1].FuelAmount / ((DataSource.Fuels[(int)view.Tag - 1].FuelCarMilage - DataSource.Fuels[(int)view.Tag].FuelCarMilage) / 100), 1);
                                    DataSource.Fuels[(int)view.Tag - 1].FuelPricePerKm = Math.Round(DataSource.Fuels[(int)view.Tag - 1].FuelPricePerLiter / (100 / DataSource.Fuels[(int)view.Tag - 1].FuelConsumption), 2);


                                    break;
                                }
                                    
                            }
                            else
                            {
                                //if it is not double return initial value
                                view.StringValue = Convert.ToString(DataSource.Fuels[(int)view.Tag].FuelCarMilage);
                                break;
                            }

                        case "GasStation":
                            DataSource.Fuels[(int)view.Tag].FuelGasStation = view.StringValue;
                            break;
                        case "PriceTotal":
                            if (IsDouble(view.StringValue))
                            {
                                DataSource.Fuels[(int)view.Tag].FuelPriceTotal = Convert.ToDouble(view.StringValue);
                                DataSource.Fuels[(int)view.Tag].FuelPricePerLiter = Math.Round(DataSource.Fuels[(int)view.Tag].FuelPriceTotal / DataSource.Fuels[(int)view.Tag].FuelAmount, 2);
                                DataSource.Fuels[(int)view.Tag].FuelConsumption = Math.Round(DataSource.Fuels[(int)view.Tag].FuelAmount / ((DataSource.Fuels[(int)view.Tag].FuelCarMilage - DataSource.Fuels[(int)view.Tag + 1].FuelCarMilage) / 100), 1);
                                DataSource.Fuels[(int)view.Tag].FuelPricePerKm = Math.Round(DataSource.Fuels[(int)view.Tag].FuelPricePerLiter / (100 / DataSource.Fuels[(int)view.Tag].FuelConsumption), 2);
                                break;
                            }
                            else
                            {
                                view.StringValue = Convert.ToString(DataSource.Fuels[(int)view.Tag].FuelPriceTotal);
                                break;
                            }
                           
                    }
                }
                else
                {
                    //last line
                    switch (view.Identifier)
                    {
                        case "CarMilage":
                            if (view.Tag == 0)
                            {
                                DataSource.Fuels[(int)view.Tag].FuelCarMilage = Convert.ToDouble(view.StringValue);
                                break;
                            }
                            else
                            {
                                //given line
                                DataSource.Fuels[(int)view.Tag].FuelCarMilage = Convert.ToDouble(view.StringValue);
                                //line above
                                DataSource.Fuels[(int)view.Tag-1].FuelConsumption = Math.Round(DataSource.Fuels[(int)view.Tag-1].FuelAmount / ((DataSource.Fuels[(int)view.Tag-1].FuelCarMilage - DataSource.Fuels[(int)view.Tag].FuelCarMilage) / 100), 1);
                                DataSource.Fuels[(int)view.Tag-1].FuelPricePerKm = Math.Round(DataSource.Fuels[(int)view.Tag-1].FuelPricePerLiter / (100 / DataSource.Fuels[(int)view.Tag-1].FuelConsumption), 2);
                                break;
                            }

                    }


                }

            };


            // Tag view
            view.Tag = row;

            // Input dat in the cell based on the column 
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







    }
}


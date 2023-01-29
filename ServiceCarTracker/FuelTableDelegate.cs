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

        #region Override Methods
        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            // This pattern allows you reuse existing views when they are no-longer in use.
            // If the returned view is null, you instance up a new view
            // If a non-null view is returned, you modify it enough to reflect the new data
            NSTextField view = (NSTextField)tableView.MakeView(CellIdentifier, this);
            if (view == null)
            {
                view = new NSTextField();
                view.Identifier = CellIdentifier;
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Selectable = false;
                view.Editable = false;
            }

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

 
	}
}


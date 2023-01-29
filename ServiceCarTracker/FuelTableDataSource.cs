using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;
using StoreKit;

namespace ServiceCarTracker
{
	public class FuelTableDataSource : NSTableViewDataSource
	{
		public List<Fuel> Fuels = new List<Fuel>();

        public FuelTableDataSource()
		{
		}

        public override nint GetRowCount(NSTableView tableView)
        {
            return Fuels.Count;
        }
    }
}


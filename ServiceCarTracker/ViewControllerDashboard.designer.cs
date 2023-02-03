// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ServiceCarTracker
{
	[Register ("ViewControllerDashboard")]
	partial class ViewControllerDashboard
	{
		[Outlet]
		AppKit.NSTextField AvgConsumptionDash { get; set; }

		[Outlet]
		AppKit.NSTextField AvgPricePerKmDash { get; set; }

		[Outlet]
		AppKit.NSTextField TotalPriceFuelDash { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AvgConsumptionDash != null) {
				AvgConsumptionDash.Dispose ();
				AvgConsumptionDash = null;
			}

			if (AvgPricePerKmDash != null) {
				AvgPricePerKmDash.Dispose ();
				AvgPricePerKmDash = null;
			}

			if (TotalPriceFuelDash != null) {
				TotalPriceFuelDash.Dispose ();
				TotalPriceFuelDash = null;
			}
		}
	}
}

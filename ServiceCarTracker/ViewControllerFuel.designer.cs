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
	[Register ("ViewControllerFuel")]
	partial class ViewControllerFuel
	{
		[Outlet]
		AppKit.NSTableColumn FuelAmountClm { get; set; }

		[Outlet]
		AppKit.NSTableColumn FuelCarMilageClm { get; set; }

		[Outlet]
		AppKit.NSTableColumn FuelConsumptionClm { get; set; }

		[Outlet]
		AppKit.NSTableColumn FuelDateClm { get; set; }

		[Outlet]
		AppKit.NSTableColumn FuelGasStationClm { get; set; }

		[Outlet]
		AppKit.NSTableColumn FuelPricePerKmClm { get; set; }

		[Outlet]
		AppKit.NSTableColumn FuelPricePerLiterClm { get; set; }

		[Outlet]
		AppKit.NSTableColumn FuelPriceTotalClm { get; set; }

		[Outlet]
		AppKit.NSTableView FuelTable { get; set; }

		[Outlet]
		AppKit.NSTextField TxtFldAmountFuel { get; set; }

		[Outlet]
		AppKit.NSTextField TxtFldCarMilageFuel { get; set; }

		[Outlet]
		AppKit.NSTextField TxtFldDateFuel { get; set; }

		[Outlet]
		AppKit.NSTextField TxtFldGasStationFuel { get; set; }

		[Outlet]
		AppKit.NSTextField TxtFldPriceTotalFuel { get; set; }

		[Action ("BtnInsertDataFuel:")]
		partial void BtnInsertDataFuel (AppKit.NSButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (TxtFldDateFuel != null) {
				TxtFldDateFuel.Dispose ();
				TxtFldDateFuel = null;
			}

			if (TxtFldAmountFuel != null) {
				TxtFldAmountFuel.Dispose ();
				TxtFldAmountFuel = null;
			}

			if (TxtFldPriceTotalFuel != null) {
				TxtFldPriceTotalFuel.Dispose ();
				TxtFldPriceTotalFuel = null;
			}

			if (TxtFldCarMilageFuel != null) {
				TxtFldCarMilageFuel.Dispose ();
				TxtFldCarMilageFuel = null;
			}

			if (TxtFldGasStationFuel != null) {
				TxtFldGasStationFuel.Dispose ();
				TxtFldGasStationFuel = null;
			}

			if (FuelTable != null) {
				FuelTable.Dispose ();
				FuelTable = null;
			}

			if (FuelDateClm != null) {
				FuelDateClm.Dispose ();
				FuelDateClm = null;
			}

			if (FuelAmountClm != null) {
				FuelAmountClm.Dispose ();
				FuelAmountClm = null;
			}

			if (FuelPriceTotalClm != null) {
				FuelPriceTotalClm.Dispose ();
				FuelPriceTotalClm = null;
			}

			if (FuelPricePerLiterClm != null) {
				FuelPricePerLiterClm.Dispose ();
				FuelPricePerLiterClm = null;
			}

			if (FuelCarMilageClm != null) {
				FuelCarMilageClm.Dispose ();
				FuelCarMilageClm = null;
			}

			if (FuelConsumptionClm != null) {
				FuelConsumptionClm.Dispose ();
				FuelConsumptionClm = null;
			}

			if (FuelPricePerKmClm != null) {
				FuelPricePerKmClm.Dispose ();
				FuelPricePerKmClm = null;
			}

			if (FuelGasStationClm != null) {
				FuelGasStationClm.Dispose ();
				FuelGasStationClm = null;
			}
		}
	}
}

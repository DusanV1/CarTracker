using System;
using AppKit;
using Foundation;
using static System.Net.Mime.MediaTypeNames;

namespace ServiceCarTracker
{
	[Register ("AppDelegate")]
	public class AppDelegate : NSApplicationDelegate
	{
		public AppDelegate ()
		{
		}

		public override void DidFinishLaunching (NSNotification notification)
		{
			// Insert code here to initialize your application
		}

		public override void WillTerminate (NSNotification notification)
		{
			// Insert code here to tear down your application
		}

        public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender)
        {

            return true;

        }

        public override NSApplicationTerminateReply ApplicationShouldTerminate(NSApplication sender)
        {
            var confirmation = new NSAlert()
            {
                AlertStyle = NSAlertStyle.Warning,
                InformativeText = "Do you want to save the data",
                MessageText = "Save data"
            };
            confirmation.AddButton("Yes");
            confirmation.AddButton("No");
            var result = confirmation.RunModal();

            if (result == 1000)
            {
                
                string location = System.IO.Directory.GetCurrentDirectory();
                location = location.Substring(0, location.IndexOf("/bin"));

                //ViewControllerFuel.JsonStorage(ViewControllerFuel.DataSource.Fuels, "/Users/dusan/My_data/obecne/CSharp/ServiceCarTrackerApplication/ServiceCarTracker/ServiceCarTracker/Fuel.json");
                ViewControllerFuel.JsonStorage(ViewControllerFuel.DataSource.Fuels, location + "/Fuel.json");
                return NSApplicationTerminateReply.Now;
            }
            else
            {
                return NSApplicationTerminateReply.Now;
            }
            //return NSApplicationTerminateReply.Cancel;
        }
    }
}


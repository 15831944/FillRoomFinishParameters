#region namespaces
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Interop;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;
using System.Drawing;
#endregion //namespaces

namespace RoomFinishes
{
    // Implements the Revit add-in interface IExternalApplication
    class Application : IExternalApplication
    {
        // Message used as ribbon panel button tooltip 
        // and displayed by the external command
        public const string Message =
          "Fill floors' walls' and ceilings finishing parameters";

        static void AddRibbonPanel(
          UIControlledApplication a)
        {
            // Method to add Tab and Panel 
            RibbonPanel panel = ribbonPanel(a);

            string path = Assembly.GetExecutingAssembly().Location;

            PushButtonData data = new PushButtonData(
              "Fill Room Finishes Parameters", "Fill Room Finishes Parameters", path, "RoomFinishes.RoomFinder");

            Bitmap bitmapicon16 = new Bitmap(@"E:\Rita\RoomFinishes\RoomFinishes\RoomFinishes\icon16.bmp");
            BitmapSource icon16 = BitmapToBitmapSource(bitmapicon16);

            Bitmap bitmapicon32 = new Bitmap(@"E:\Rita\RoomFinishes\RoomFinishes\RoomFinishes\icon32.bmp");
            BitmapSource icon32 = BitmapToBitmapSource(bitmapicon32);

            PushButton pushbutton = panel.AddItem(data) as PushButton;

            pushbutton.Image = icon16;
            pushbutton.LargeImage = icon32;
            pushbutton.ToolTip = Message;
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        // Convert a Bitmap to a BitmapSource
        static BitmapSource BitmapToBitmapSource(Bitmap bitmap)
        {
            IntPtr hBitmap = bitmap.GetHbitmap();

            BitmapSource retval;

            try
            {
                retval = Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap, IntPtr.Zero, Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                DeleteObject(hBitmap);
            }
            return retval;
        }

        public static RibbonPanel ribbonPanel(UIControlledApplication a)
        {
            string tab = "Rita Aguiar Plugins"; // Tab name
                                                // Empty ribbon panel 
            RibbonPanel ribbonPanel = null;
            // Try to create ribbon tab. 
            try
            {
                a.CreateRibbonTab(tab);
            }
            catch { }
            // Try to create ribbon panel.
            try
            {
                RibbonPanel panel = a.CreateRibbonPanel(tab, "Finishes");
            }
            catch { }
            // Search existing tab for your panel.
            List<RibbonPanel> panels = a.GetRibbonPanels(tab);
            foreach (RibbonPanel p in panels)
            {
                if (p.Name == "Finishes")
                {
                    ribbonPanel = p;
                }
            }
            //return panel 
            return ribbonPanel;
        }

        // class instance
        internal static Application thisApp = null;
        // ModelessForm instance
        private FillRoomFinishesParameters FRFPForm;

        #region IExternalApplication Members

        // Implements the OnShutdown event
        public Result OnShutdown(UIControlledApplication application)
        {
            if (FRFPForm != null && FRFPForm.Visible)
            {
                FRFPForm.Close();
            }

            return Result.Succeeded;
        }

        // Implements the OnStartup event
        public Result OnStartup(UIControlledApplication application)
        {
            AddRibbonPanel(application);
            FRFPForm = null;   // no dialog needed yet; the command will bring it
            thisApp = this;  // static access to this application instance

            return Result.Succeeded;
        }

        //   This method creates and shows a modeless dialog, unless it already exists.
        //   The external command invokes this on the end-user's request

        public void ShowForm(UIApplication uiapp)
        {
            // If we do not have a dialog yet, create and show it
            if (FRFPForm == null || FRFPForm.IsDisposed)
            {
                // A new handler to handle request posting by the dialog
                RequestHandler handler = new RequestHandler();

                // External Event for the dialog to use (to post requests)
                ExternalEvent exEvent = ExternalEvent.Create(handler);

                // We give the objects to the new dialog;
                // The dialog becomes the owner responsible for disposing them, eventually.
                FRFPForm = new FillRoomFinishesParameters(exEvent, handler, uiapp);
                FRFPForm.Show();
            }
        }

        //   Waking up the dialog from its waiting state.
        public void WakeFormUp()
        {
            if (FRFPForm != null)
            {
                FRFPForm.WakeUp();
            }
        }
        #endregion IExternalApplication Members
    }
}

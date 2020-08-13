#region namespaces
using Autodesk.Revit.UI;
#endregion // namespaces

namespace RoomFinishes
{
    public partial class RequestHandler : IExternalEventHandler
    {
        // The value of the latest request made by the modeless form 
        private Request m_request = new Request();

        // A public property to access the current request value
        public Request Request
        {
            get { return m_request; }
        }

        //  A method to identify this External Event Handler
        public string GetName()
        {
            return "Revit 2019 External Event";
        }

        //The top method of the event handler

        //   This is called by Revit after the corresponding
        //   external event was raised (by the modeless form)
        //   and Revit reached the time at which it could call
        //   the event's handler (i.e. this object)

        public void Execute(UIApplication uiapp)
        {
            UIDocument uidoc = uiapp.ActiveUIDocument; // define uidoc como a propriedade ActiveUIDocument de app

            //Creates new instance everytime Excute is called by the IExternalEventHandler
            var instance = new RoomFinder();
            
            try
            {
                switch (Request.Take())
                {
                    case RequestId.None:
                        {
                            return;  // no request at this time -> we can leave immediately
                        }
                    case RequestId.FillParameters:
                        {
                            instance.SetRoomFinishingParameters(uidoc);
                            break;
                        }
                    default:
                        {
                            // some kind of a warning here should
                            // notify us about an unexpected request 
                            break;
                        }
                }
            }
            finally
            {
                Application.thisApp.WakeFormUp();
            }

            return;
        }
    }
}

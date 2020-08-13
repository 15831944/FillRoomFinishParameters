#region namespaces
using System.Threading;
#endregion //namespaces

namespace RoomFinishes
{
    //A list of requests the dialog has available
    public enum RequestId : int
    {
        // None
        None = 0,
        // "FillParameters" request
        FillParameters = 1,
    }

    //A class around a variable holding the current request.

    //   Access to it is made thread-safe, even though we don't necessarily
    //   need it if we always disable the dialog between individual requests.

    public class Request
    {
        // Storing the value as a plain Int makes using the interlocking mechanism simpler
        private int m_request = (int)RequestId.None;

        //   Take - The Idling handler calls this to obtain the latest request. 

        //   This is not a getter! It takes the request and replaces it
        //   with 'None' to indicate that the request has been "passed on".

        public RequestId Take()
        {
            return (RequestId)Interlocked.Exchange(ref m_request, (int)RequestId.None);
        }

        //Make - The Dialog calls this when the user presses a command button there. 

        //   It replaces any older request previously made.

        public void Make(RequestId request)
        {
            Interlocked.Exchange(ref m_request, (int)request);
        }
    }
}

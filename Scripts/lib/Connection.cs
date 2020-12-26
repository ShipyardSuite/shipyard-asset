using System;

namespace ShipyardClient
{
    public struct Connection
    {
        // Check online
        public void Online(Action<bool> callback) {

            Loading = true;

            if(Manager.instance.State.Online == true)
            {
               Loading = false;
                callback(true);
            }
            else
            {
                callback(false);
            }
        }

        // Connect
        public void Connect(Action<bool> callback) {

            Loading = true;

            if (Manager.instance.State.Connected == true)
            {
                Loading = false;
                callback(true);
            }
            else
            {
                callback(false);
            }
        }

        public bool Loading { get; set; }
    }
}

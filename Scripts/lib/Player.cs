using System;

namespace ShipyardClient
{
    public struct Player
    {
        public void Login(Action<bool> callback)
        {
            callback(true);
        }
    }
}
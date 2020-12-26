using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace ShipyardClient
{
    public struct State
    {
        public bool Online
        {
            get
            {
                return Application.internetReachability != NetworkReachability.NotReachable;
            }
        }

        public bool Connected
        {
            get; set;
        }

        public bool LoggedIn
        {
            get; set;
        }

        public bool LoggedOut
        {
            get; set;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipyardClient
{
    public class Manager : MonoBehaviour
    {
        private Connection connection;
        private State state;

        public static Manager instance;

        public bool isOnline;
        public bool isConnected;
                

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else Destroy(this); // or gameObject
        }

        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            isOnline = State.Online;
            isConnected = State.Connected;
        }

        public Connection Connection { get => connection; set => connection = value; }
        public State State { get => state; set => state = value; }
    }
}
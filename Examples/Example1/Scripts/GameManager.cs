using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShipyardClient;

namespace Examples.Example1
{
    public class GameManager : MonoBehaviour
    {
        public Manager manager;

        [Header("GUI")]
        public GameObject loadingIndicator;
        public GameObject connectPanel;
        public GameObject loginPanel;

        // Start is called before the first frame update
        void Start()
        {
            manager = Manager.instance;

            loadingIndicator.SetActive(true);
            connectPanel.SetActive(false);
            loginPanel.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            manager.Connection.Online(status =>
            {
                if(status == true)
                {
                    loadingIndicator.SetActive(false);
                    connectPanel.SetActive(true);
                }
            });
        }

        public void ClickConnectButton()
        {
            loadingIndicator.SetActive(true);
            manager.Connection.Connect(status =>
            {
                loadingIndicator.SetActive(false);
                connectPanel.SetActive(false);
                loginPanel.SetActive(true);
            });
        }
    }
}

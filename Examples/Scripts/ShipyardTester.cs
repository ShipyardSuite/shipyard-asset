using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using ShipyardSDK;

public class ShipyardTester : MonoBehaviour
{
	public ShipyardManager manager;

	public GameObject loadingText;
	public GameObject connectionPanel;
	public GameObject messageOfTheDayPanel;
	public GameObject loginPanel;
	public GameObject gamePanel;

	public InputField userNameField;

    private void Awake()
    {
		manager = ShipyardManager.Instance;
	}

    // Start is called before the first frame update
    void Start()
	{
		connectionPanel.SetActive(true);
	}

	public void ClickConnectButton()
	{
		loadingText.SetActive(true);

		manager.Connect((status) =>
		{
            if(status == true)
            {
				loadingText.SetActive(false);
				connectionPanel.SetActive(false);

                //manager.GetMessageOfTheDay((messageAmount) =>
                //{
                loginPanel.SetActive(true);

                //                if(messageAmount > 0)
                //                {
                //		messageOfTheDayPanel.SetActive(true);
                //	}
                //});
            }
		});
	}

    public void ClickLoginButton()
    {
		loadingText.SetActive(true);

		manager.LoginPlayer(userNameField.text, (status) => {
			messageOfTheDayPanel.SetActive(false);
			loginPanel.SetActive(false);

			//manager.GetContent((contentStatus) =>
			//{
			//	loadingText.SetActive(false);
				

			//	gamePanel.GetComponent<GamePanel>().PopulatePlayerInfoPanel(manager.player.name, manager.player.id);
			//	gamePanel.SetActive(true);
			//});
		});
	}
}

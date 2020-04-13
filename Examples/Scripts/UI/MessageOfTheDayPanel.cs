using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

using ShipyardSDK;

public class MessageOfTheDayPanel : MonoBehaviour
{
    public ShipyardManager manager;

    public GameObject prevButton;
    public GameObject nextButton;
    public RawImage messageImage;
    public TMP_Text messageTitle;
    public TMP_Text messageText;

    public int activeMessage = 0;
    public int messageAmount = 0;

    public List<MessageOfTheDay> messages = new List<MessageOfTheDay>();

    private void Awake()
    {
        manager = ShipyardManager.Instance;

        manager.messages.ForEach(message => {
            if (message.active == true)
            {
                messageAmount++;
                messages.Add(message);
            }
        });
    }

    // Use this for initialization
    void Start()
    {
        if (messageAmount == 0)
        {
            prevButton.SetActive(false);
            nextButton.SetActive(false);
        }
        PopulateMessage(activeMessage);
    }

    // Update is called once per frame
    void Update()
    {
        //PopulateMessage(activeMessage);
    }

    void PopulateMessage(int number)
    {
        GetNewMessage(number);
    }

    void GetNewMessage(int messageNR)
    {
        if(messages[messageNR].imageURL != null)
        {
            manager.DownloadImage(messages[messageNR].imageURL, (image) =>
            {
                messageImage.texture = image.texture;
                messageTitle.text = messages[messageNR].title;
                messageText.text = messages[messageNR].text;
            });
        }
        else
        {
            messageImage.texture = null;
            messageTitle.text = messages[messageNR].title;
            messageText.text = messages[messageNR].text;
        }
    }

    public void nextMessage()
    {
        if (activeMessage <= messageAmount - 2)
        {
            activeMessage++;
        }
        else
        {
            activeMessage = 0;
        }
        PopulateMessage(activeMessage);
    }

    public void prevMessage()
    {
        if(activeMessage > 0)
        {
            activeMessage--;
        }
        else
        {
            activeMessage = messageAmount - 1;
        }
        PopulateMessage(activeMessage);
    }
}

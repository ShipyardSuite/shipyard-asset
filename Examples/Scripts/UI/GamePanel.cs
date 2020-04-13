using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePanel : MonoBehaviour
{
    public TMP_Text playerNameText;
    public TMP_Text playerIdText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopulatePlayerInfoPanel(string name, string id)
    {
        playerNameText.text = name;
        playerIdText.text = $"({id})";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShipyardSDK;

public class GameManager : MonoBehaviour
{
    public ShipyardManager manager;

    public TestAsset testAsset;

    public Sprite testSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ShipyardManager.Instance.isLoggedIn)
        {
            testAsset = new TestAsset("shotgun");

            testSprite = Resources.Load("Sprites/" + testAsset.id, typeof(Sprite)) as Sprite;
        }
    }
}

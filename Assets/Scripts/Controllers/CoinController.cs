using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour

{
    public Text cointext;

    public static CoinController instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("More than one coincontroller in the Scene");
        }
    }

    /*
    private void Start()
    {
        coin = 50;
    }
    */


    public void UpdateText(int coins)
    {
        if (cointext.text != coins.ToString())
        {
            cointext.text = coins.ToString();
        }
    }
}

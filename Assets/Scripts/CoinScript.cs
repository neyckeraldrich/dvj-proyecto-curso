using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI coinCounter;

    private static int totalCoins = 0;

    private bool done = false;

    private void Awake()
    {
        coinCounter = Array.Find(FindObjectsOfType<TMPro.TextMeshProUGUI>(), text => text.name.Equals("CoinsCounter"));
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player") && !done)
        {
            done = true;
            totalCoins += 1;
            coinCounter.text = totalCoins.ToString();
            FindObjectOfType<AudioManager>().Play("CoinTaken");
            Destroy(gameObject);
            //ScoreTextScript.coinAmount += 1;
            //ScoreTextScript.coinAmount = ScoreTextScript.coinAmount + 1;
            //Destroy(gameObject);
        }
    }
}

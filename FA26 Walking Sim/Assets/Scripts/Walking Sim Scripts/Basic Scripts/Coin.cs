using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // reference to our game manager
    GameManager gameManager;

    private void Start()
    {
        // since only one Game Manager, we'll be able to find the one we need
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the player touches me
        if (other.gameObject.tag == "Player")
        {
            // collect me
            gameManager.CollectCoin();

            // then, set me inactive
            gameObject.SetActive(false);
        }
    }
}
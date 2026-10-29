using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject endScreenBackground;
    public GameObject endScreenLoseMessage;
    public GameObject endScreenWinMessage;

    bool canPlayerRestart;
    bool canPlayerReturnToMainMenu;

    // how many coins we've collected
    public int coinCount;

    // player lives
    public int startingPlayerLives = 3;
    int currentPlayerLives = 3;

    // Assign these references in Inspector
    public Transform respawnLocation;
    public GameObject player;
    // how many coins player has to collect before something happens
    public int coinRequirement = 1;
    public int[] coinRequirements;

    // reference to our door we need to open, assign in Inspector
    public GameObject door;

    // reference to the text on screen showing our coinCount
    public TextMeshProUGUI coinCountText;

    // reference to a sound effect
    public AudioClip coinCollectSound;

    // CollectCoin is a function being called by the Coin script when we collect a coin
    // a function is a list of code for the computer to execute in order from top to bottom
    public void CollectCoin()
    {
        // we're getting the component called Audio Source on this gameObject
        // you'll need to add that component in Unity for this to work!

        // then playing a function from the Audio Source, passing in the AudioClip as a parameter
        // this code only runs if we've assigned a coinCollectSound
        if (coinCollectSound != null)
        {
            GetComponent<AudioSource>().PlayOneShot(coinCollectSound);
        }

        // increment our coin count
        // coinCount = coinCount + 1;
        // adding 1 to our coin count
        coinCountText.gameObject.SetActive(true);
        coinCount++;

        // display the new coin count to the screen
        //coinCountText.text = "Coins: " + coinCount.ToString();
        coinCountText.text = "Coins: " + coinCount.ToString();

        if (coinCount >= coinRequirement)
        {
            // open the door
            //door.SetActive(false);

            // win message
            endScreenBackground.SetActive(true);
            endScreenWinMessage.SetActive(true);
            canPlayerReturnToMainMenu = true;
        }
    }

    public void LoseLife()
    {
        // decrement how many lives the player has
        currentPlayerLives--;

        if (currentPlayerLives <= 0)
        {
            endScreenBackground.SetActive(true);
            endScreenLoseMessage.SetActive(true);
            canPlayerRestart = true;

            // respawn
            //currentPlayerLives = startingPlayerLives;
            //player.transform.position = respawnLocation.position;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (canPlayerRestart)
            {
                // reload the current scene
                SceneManager.LoadScene(1);
            }
            else if (canPlayerReturnToMainMenu)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
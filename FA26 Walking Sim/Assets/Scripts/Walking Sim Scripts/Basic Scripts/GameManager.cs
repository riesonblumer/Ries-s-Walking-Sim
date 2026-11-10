using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    [Header("End Screens / Restart")]
    public GameObject endScreenBackground;
    public GameObject endScreenLoseMessage;
    public GameObject endScreenWinMessage;
    // how many coins player has to collect to win
    public int coinRequirement = 1;
    bool canPlayerRestart;
    bool canPlayerReturnToMainMenu;

    [Header("Player State")]
    public TextMeshProUGUI timeText;
    float timePassed;
    // how many coins we've collected
    public int coinCount;
    // reference to the text on screen showing our coinCount
    public TextMeshProUGUI coinCountText;
    // player lives
    public int startingPlayerLives = 3;
    int currentPlayerLives = 3;
    public TextMeshProUGUI livesText;
    // Assign these references in Inspector
    public Transform respawnLocation;
    public GameObject player;

    [Header("Audio")]
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
        coinCount++;

        if (coinCountText != null)
        {
            coinCountText.gameObject.SetActive(true);

            // display the new coin count to the screen
            //coinCountText.text = "Coins: " + coinCount.ToString();
            coinCountText.text = "Coins: " + coinCount.ToString();
        }

        if (coinCount >= coinRequirement)
        {
            // win message
            if (endScreenBackground != null) endScreenBackground.SetActive(true);
            if (endScreenWinMessage != null) endScreenWinMessage.SetActive(true);
            canPlayerReturnToMainMenu = true;
        }
    }

    // you'll have to call this function whenever the player should lose a life!
    public void LoseLife()
    {
        // decrement how many lives the player has
        currentPlayerLives--;

        if (livesText != null)
        {
            livesText.gameObject.SetActive(true);
            livesText.text = "Lives: " + currentPlayerLives.ToString();
        }

        if (currentPlayerLives <= 0)
        {
            if (endScreenBackground != null) endScreenBackground.SetActive(true);
            if (endScreenLoseMessage != null) endScreenLoseMessage.SetActive(true);
            canPlayerRestart = true;
        }
        else
        {
            // respawn
            player.transform.position = respawnLocation.position;
        }
    }

    private void Update()
    {
        // Note: for this to work, you'll need two scenes in your build settings
        // At index 0, you'll have your main menu scene
        // At index 1, you'll have your game scene
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

        if (canPlayerRestart || canPlayerReturnToMainMenu) return;

        timePassed += Time.deltaTime;

        if (timeText != null)
        {
            timeText.text = "Time: " + timePassed;
        }
        else
        {
            timeText.gameObject.SetActive(false);
        }
    }
}
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
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Projectile")
        {
            // collect me
            if (gameManager != null) gameManager.CollectCoin();

            // then, set me inactive
            gameObject.SetActive(false);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Danger : MonoBehaviour
{
    public bool shouldResetScene;
    public bool shouldRespawnPlayer;

    // create an empty GameObject and put it where we would want the player to respawn
    public Transform respawn;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (shouldResetScene)
            {
                // you need to add the scene in the build settings
                // File > Build Settings, Add Open Scenes
                // and make sure your scene is the only one checked
                SceneManager.LoadScene(0);
            }
            else if (shouldRespawnPlayer)
            {
                // put the player at the respawn point
                other.transform.position = respawn.position;
            }
        }
    }
}

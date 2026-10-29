using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneAfter : MonoBehaviour
{
    public float timeSinceSceneBegan;
    public float timeAtWhichToRestartScene = 10f;

    // Update is called once per frame
    void Update()
    {
        timeSinceSceneBegan += Time.deltaTime;

        if (timeSinceSceneBegan >= timeAtWhichToRestartScene)
        {
            // you need to add the scene in the build settings
            // File > Build Settings, Add Open Scenes
            // and make sure your scene is the only one checked
            SceneManager.LoadScene(0);
        }
    }
}

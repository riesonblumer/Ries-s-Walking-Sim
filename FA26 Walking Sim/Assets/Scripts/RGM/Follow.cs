using UnityEngine;

public class Follow : MonoBehaviour
{
    // thingToFollow is the rolling ball
    public GameObject thingToFollow;

    void Update()
    {
        // example: make the camera's position the same as the ball's position
        transform.position = thingToFollow.transform.position;
    }
}
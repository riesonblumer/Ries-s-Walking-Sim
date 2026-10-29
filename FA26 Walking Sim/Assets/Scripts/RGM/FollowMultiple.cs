using UnityEngine;

public class FollowMultiple : MonoBehaviour
{
    public Transform cameraBeingHeld;

    [Header("Thing To Follow 1")]
    public float timeToSwitch1;
    public GameObject thingToFollow;
    public Vector3 cameraAnglePostion1 = new Vector3(0f, 0f, 0f);
    public Vector3 cameraAngleRotation1 = new Vector3(0f, 0f, 0f);    


    [Header("Thing to Follow 2")]
    // times (in seconds) to switch camera
    public float timeToSwitch2;
    public GameObject thingToFollow2;
    public Vector3 cameraAnglePostion2 = new Vector3(0f, 0f, 0f);
    public Vector3 cameraAngleRotation2 = new Vector3(0f, 0f, 0f);

    [Header("Thing to Follow 3")]
    public GameObject thingToFollow3;
    public Vector3 cameraAnglePostion3 = new Vector3(0f, 0f, 0f);
    public Vector3 cameraAngleRotation3 = new Vector3(0f, 0f, 0f);

    [Header("Time Since Start")]
    public float time = 0f;

    void Update()
    {
        // keeps track of how much time has passed since we pressed play
        // we need to keep track of how much time has passed
        time = time + Time.deltaTime;

        if (time < timeToSwitch1)
        {
            // this game object will set its position to the thingToFollow's position every frame
            transform.position = thingToFollow.transform.position;
            cameraBeingHeld.localPosition = cameraAnglePostion1;
            cameraBeingHeld.localEulerAngles = cameraAngleRotation1;
        }
        else if (time < timeToSwitch2 && thingToFollow2 != null)
        {
            transform.position = thingToFollow2.transform.position;
            cameraBeingHeld.localPosition = cameraAnglePostion2;
            cameraBeingHeld.localEulerAngles = cameraAngleRotation2;
        }
        else if (thingToFollow3 != null)
        {
            transform.position = thingToFollow3.transform.position;
            cameraBeingHeld.localPosition = cameraAnglePostion3;
            cameraBeingHeld.localEulerAngles = cameraAngleRotation3;
        }
    }
}
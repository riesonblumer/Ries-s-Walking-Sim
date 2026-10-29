using UnityEngine;

public class LookWithMouse : MonoBehaviour
{
    // IMPORTANT: this script should be attached to the Camera, not the Player
    // this script ONLY effects the "pitch" of the camera
    // turning left and right is handled with the BetterMovement script

    public bool shouldHideMouse = true;
    
    // pitch is rotation around the horizontal x axis (tilting up and down)
    float pitch = 0f;
    public float minimumPitch = -40f;
    public float maximumPitch = 20f;
    // we can tune the sensitivity in the Inspector!
    public float pitchSensitivity = 2f;

    private void Start()
    {
        if (shouldHideMouse)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // get the change in pitch since last frame
        pitch -= pitchSensitivity * Input.GetAxis("Mouse Y");

        // clamp the pitch to stay between two values (minimumPitch & maximumPitch)
        pitch = Mathf.Clamp(pitch, minimumPitch, maximumPitch);

        // apply the new pitch
        transform.eulerAngles = new Vector3(pitch, transform.eulerAngles.y, 0f);
    }
}
using UnityEngine;

public class TranslateForward : MonoBehaviour
{
    // change the direction of travel in the Inspector
    public Vector3 travelDirection = Vector3.forward;

    // start time for travel
    public float moveStartTime = 0f;
    public float timeSinceStart;

    // change this variable in the Inspector
    // can go negative to reverse direction!
    public float speed = 1f;

    // Reminder: Update() is called once per frame
    void Update()
    {
        // The symbol * (asterisk) is for multiplication!

        // Time.deltaTime means the time that has passed since the last frame update.

        // Since translation is basically like teleporting...
        // we are teleporting by very very small increments each frame...
        // (unless you make the speed value very big!)

        timeSinceStart += Time.deltaTime;

        // if it's time to start moving, we start running the Move function
        if (timeSinceStart > moveStartTime)
        {
            Move();
        }
    }

    void Move()
    {
        // Vector3.forward is shorthand for Vector3(0f, 0f, 1f), where the only non-zero value is z
        transform.Translate(travelDirection * Time.deltaTime * speed);
    }
}
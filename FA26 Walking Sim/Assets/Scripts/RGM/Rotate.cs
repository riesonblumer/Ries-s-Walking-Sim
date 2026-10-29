using UnityEngine;

public class Rotate : MonoBehaviour
{
    // the axis around which this GameObject rotates
    // Vector3.up is shorthand for Vector3(0f, 1f, 0f) where the only non-zero value is y
    public Vector3 axisToRotateAround = Vector3.up;

    // oscillation variables are more advanced!
    // no need to worry about these for now
    // can safely ignore if shouldOscillate stays false
    public bool shouldOscillate;
    public float oscillationTime = 2f;
    public float timeSinceOscillation;

    // speed of rotation and when to start rotating
    public float speed = 1f;
    public float rotateStartTime = 3f;
    public float timeSinceStart;

    void Update()
    {
        // Time.deltaTime means the time that has passed since the last frame update.
        // Since we are adding this value to timeSinceStart each frame...
        // we are effectively keeping track of how much time has passed since we pressed Play.
        timeSinceStart += Time.deltaTime;

        // if it's time to start rotating, we start running the RotateThing function
        if (timeSinceStart > rotateStartTime)
        {
            RotateThing();
        }
    }

    void RotateThing()
    {
        transform.Rotate(axisToRotateAround * Time.deltaTime * speed);

        // oscillation code below can be ignored!
        if (shouldOscillate)
        {
            timeSinceOscillation += Time.deltaTime;

            if (timeSinceOscillation > oscillationTime)
            {
                speed *= -1f;
                timeSinceOscillation = 0f;
            }
        }
    }
}

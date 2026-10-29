using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{
    // script for moving on x-z plane

    // since these variables are public, you can tune them in the Inspector!
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    void Update()
    {
        // get horizontal and vertical axis
        // by default vertical is mapped to W/S or the arrow keys (up/down)
        // by default horizontal is mapped to A/D or the arrow keys (left/right)
        // the value is in range -1f to 1f
        // as an example, when the W key is being pressed, Input.GetAxis("Vertical") returns a value of 1f
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // we multiply our values by Time.deltaTime to reduce them to something manageable
        // since Update runs every frame, a speed of 10 would make us go very fast without this
        // Time.deltaTime equals "time in seconds since the last frame" and is usually a very small value 
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // move translation along the object’s z-axis
        transform.Translate(0, 0, translation);

        // rotate around y-axis
        transform.Rotate(0, rotation, 0);
    }
}
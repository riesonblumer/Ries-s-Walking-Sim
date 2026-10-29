using UnityEngine;

public class BetterMovement : MonoBehaviour
{
    // later, we'll need this reference to the player's rigidbody
    Rigidbody rb;

    // variable to adjust our overall movement speed, tune in Inspector!
    // default speed
    public float defaultMovementSpeed = 5f;
    // this will be added to base movement speed
    public float sprintSpeedIncrease = 2f;
    public float climbSpeed = 3f;
    float currentMovementSpeed = 5f;

    bool shouldClimb;

    // variables used to turn left and right with mouse
    // yaw is the rotation around the vertical y axis (turning left and right)
    float yaw = 0f;
    // we can tune the sensitivity in the Inspector!
    public float yawSensitivity = 2f;

    void Start()
    {
        // assign variable rb as the Rigidbody component on this gameObject
        rb = GetComponent<Rigidbody>();

        currentMovementSpeed = defaultMovementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Move();
    }

    void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentMovementSpeed += sprintSpeedIncrease;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentMovementSpeed = defaultMovementSpeed;
        }
    }

    void Move()
    {
        //transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")));
        // before, we used the line above, but now we'll use the code below
        // so that we can control speed and no longer phase through walls


        // Move Forward, Back, Side to Side
        // value for forward/back movement
        float forwardBackMovement = Input.GetAxis("Vertical") * currentMovementSpeed;
        // strafe value for lateral movement
        float strafeMovement = Input.GetAxis("Horizontal") * currentMovementSpeed;

        // construct our movement vector
        Vector3 movementVector =
            (transform.forward * forwardBackMovement) +
            (transform.right * strafeMovement);

        // refine our movement vector so that the y value is not overwritten
        // just retain whatever is the current velocity.y value
        // (we can't override our y value if we want to jump!)
        movementVector = new Vector3(movementVector.x, rb.velocity.y, movementVector.z);


        // Climb?
        // if we are climbing, we can override velocity y, effectively disabling jump
        if (shouldClimb)
        {
            Vector3 climbVector = transform.up * climbSpeed;

            movementVector = new Vector3(movementVector.x, climbVector.y, movementVector.z);
        }


        // Apply Movement
        // use and apply the movement vector we created
        rb.velocity = movementVector;


        // Turn Left and Right
        // we also use the code below to turn left and right
        // this is similar implementation to our LookWithMouse script!
        yaw += yawSensitivity * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yaw, 0f);
    }


    // this event function runs if both colliders are not isTrigger (isTrigger unchecked or == false)
    private void OnCollisionStay(Collision other)
    {
        // if the player is colliding with a wall
        if (other.gameObject.tag == "Climbable")
        {
            shouldClimb = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        // if the player stops touching a wall
        if (other.gameObject.tag == "Climbable")
        {
            shouldClimb = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 7f;

    public float groundDrag = 5f;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    private bool isGrounded = false;

    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 direction;

    Rigidbody rb;

    private void Start()
    {
        //Set rb to player rigidbody
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //Check if player is on ground using raycast from player position
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        UserInputs();
        SpeedControl();

        //Apply drag if player is on ground:
        if (isGrounded) rb.drag = groundDrag;
        else rb.drag = 0f;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void UserInputs()
    {
        //Get Horizontal and Vertical inputs (WASD or Arrow keys)
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        //Calculate direction of movement
        direction = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(direction.normalized * movementSpeed * 10f, ForceMode.Force);
    }

    void SpeedControl()
    {
        // store player's current velocity in flatVelocity
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit player's velocity if higher than max speed
        if (flatVelocity.magnitude > movementSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * movementSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }
}
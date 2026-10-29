using UnityEngine;

public class Slide : MonoBehaviour
{
    public BetterMovement movementScript;
    public Collider playerCollider;
    public float slideFriction = 0f;
    public float normalFriction = .6f;
    
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerCollider.material.dynamicFriction = slideFriction;
            //rb.AddForce(transform.forward * slideForce, ForceMode.Impulse);
            //movementScript.isSliding = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerCollider.material.dynamicFriction = normalFriction;
            //movementScript.isSliding = false;
        }
    }
}
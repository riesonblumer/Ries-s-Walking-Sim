using UnityEngine;
public class Jump : MonoBehaviour
{
    // jumpForce is a public variable, accessible from other scripts
    // and will show up in the Inspector
    public float jumpForce = 10f;
    
    // rb is a private var
    Rigidbody rb;

    // this is a public var so we can check whether the player is grounded from the Inspector
    public bool isPlayerGrounded;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>(); //this finds a Rigidbody attached to this gameObject
    }

    void Update()
    {
        CheckForJump();
    }

    public void CheckForJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isPlayerGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isPlayerGrounded = false;
        }
    }
}
using UnityEngine;
public class JumpBasic : MonoBehaviour
{
    // jumpForce is a public variable, accessible from other scripts
    // and will show up in the Inspector
    public float jumpForce = 10f;

    // rb is a private var
    Rigidbody rb;

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
}
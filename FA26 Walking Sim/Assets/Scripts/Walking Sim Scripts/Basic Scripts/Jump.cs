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

    public BetterMovement movementScript;
    bool isOnVine;

    Vector3 rotationBeforeGrabbingVine;

    // for one second after jumping off vine we can't grab vine again
    [SerializeField] float vineGrabCooldown = 1f;
    float vineGrabCooldownTimer;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>(); //this finds a Rigidbody attached to this gameObject
    }

    void Update()
    {
        vineGrabCooldownTimer -= Time.deltaTime;

        CheckForJump();
    }

    public void CheckForJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnVine)
        {
            vineGrabCooldownTimer = vineGrabCooldown;

            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

            movementScript.enabled = true;
            GetComponent<Rigidbody>().useGravity = true;

            isOnVine = false;
            transform.parent = null;

            transform.rotation = Quaternion.Euler(rotationBeforeGrabbingVine);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isPlayerGrounded)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grab" && vineGrabCooldownTimer <= 0f)
        {
            rotationBeforeGrabbingVine = transform.rotation.eulerAngles;

            // grab the vine
            movementScript.enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;

            isOnVine = true;
            transform.parent = other.transform;
        }
    }
}
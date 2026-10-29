using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickupBox : MonoBehaviour
{

    private bool isInRange = false;
    private bool pickedUpBox = false;
    Transform playerTransform;
    Transform originalTransform;
    GameObject pickupBoxGameObject;
    public TextMeshProUGUI interactText;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.GetComponent<Transform>();
        //Record original parent of the box
        originalTransform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            interactText.enabled = true;

            //If player presses down E
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (pickedUpBox == false)
                {
                    Debug.Log("Pickup box!!");
                    //Remove interact text
                    interactText.enabled = false;
                    //Set the parent of the box (not hitbox) to the player
                    pickupBoxGameObject.transform.parent.SetParent(playerTransform, true);
                    pickupBoxGameObject.transform.parent.SetParent(originalTransform, false);
                }
                else if (pickedUpBox == true)
                {
                    Debug.Log("Set down box...");
                    //Set the parent of the box (not hitbox) to the original parent
                    pickupBoxGameObject.transform.parent.SetParent(playerTransform, false);
                    pickupBoxGameObject.transform.parent.SetParent(originalTransform, true);
                }
            }
        }
        else
        {
            interactText.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.J)) Debug.Log(pickupBoxGameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Each box has a seperate hitbox that's a child of the box
        //The hitbox has a tag of "Pickup"
        if (other.gameObject.CompareTag("Pickup"))
        {
            isInRange = true;
            pickupBoxGameObject = other.gameObject;
            Debug.Log("IN RANGE of ${pickupBoxGameObject}");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Each box has a seperate hitbox that's a child of the box
        //The hitbox has a tag of "Pickup"
        if (other.gameObject.CompareTag("Pickup"))
        {
            isInRange = false;
        }
    }
}
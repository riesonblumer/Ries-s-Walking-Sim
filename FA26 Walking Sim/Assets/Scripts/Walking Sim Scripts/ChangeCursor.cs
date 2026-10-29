using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    public Texture2D customCursor;
    public Vector2 hotspot = new Vector2(.25f, .25f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Cursor.SetCursor(customCursor, hotspot, CursorMode.Auto);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Cursor.visible = false;
        }
    }
}

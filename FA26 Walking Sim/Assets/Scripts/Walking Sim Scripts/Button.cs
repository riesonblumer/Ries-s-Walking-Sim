using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public bool canBePressedByProjectile = true;
    public UnityEvent eventOnButtonPress;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Press();
        }
    }

    void Press()
    {
        if (eventOnButtonPress != null)
        {
            eventOnButtonPress.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearThingOnImpact : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Vulnerable")
        {
            other.gameObject.SetActive(false);
        }
    }
}

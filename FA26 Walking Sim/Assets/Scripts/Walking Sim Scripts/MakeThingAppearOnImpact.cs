using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeThingAppearOnImpact : MonoBehaviour
{
    public GameObject thingToAppear;
    public Transform whereThingShouldAppear;

    public bool shouldShootThingOnAppearance = true;
    public float projectileSpeed = 20f;


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject spawnedObject = Instantiate(thingToAppear, whereThingShouldAppear.position, whereThingShouldAppear.transform.rotation);

            if (shouldShootThingOnAppearance)
            {
                spawnedObject.GetComponent<Rigidbody>().
                    AddForce(whereThingShouldAppear.forward * projectileSpeed, ForceMode.Impulse);
            }
        }
    }
}
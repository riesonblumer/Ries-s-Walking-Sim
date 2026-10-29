using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootProjectile : MonoBehaviour
{
    // a reference to our projectile prefab, assign in Inspector
    public GameObject projectile;

    // location to spawn in projectile, based on Camera transform or an empty GameObject child of Player, assign in Inspector
    public Transform spawnLocation;

    // can change projectile speed in Inspector
    public float projectileSpeed = 5f;

    public AudioClip projectileSound;

    private void Update()
    {
        ShootOnInput();
    }

    // this will shoot the projectile when the player presses left click!
    void ShootOnInput()
    {
        // this function runs in update, but the code below will only fire if
        // the player presses left click down and we are not in cooldown
        if (Input.GetButtonDown("Fire1"))
        {
            if (projectileSound != null && FindAnyObjectByType<GameManager>())
            {
                if (FindAnyObjectByType<GameManager>().GetComponent<AudioSource>() != null)
                {
                    FindAnyObjectByType<GameManager>().GetComponent<AudioSource>().PlayOneShot(projectileSound);
                }
            }
            
            // spawns the projectile into the world at the spawn location
            // transform.parent will get your player object if this script is on you Main Camera
            //      and the Main Camera is a child of your Player
            GameObject spawnedProjectile = Instantiate(projectile, spawnLocation.position, transform.parent.rotation);
            
            // custom rotation after instantiation
            // uncomment and edit line below to rotate your projectile
            //spawnedProjectile.transform.Rotate(90f, 0f, 0f, Space.Self);

            // shoots the projectile forward!
            // make sure your projectile has a Rigidbody attached!
            spawnedProjectile.GetComponent<Rigidbody>().
                AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
        }
    }
}
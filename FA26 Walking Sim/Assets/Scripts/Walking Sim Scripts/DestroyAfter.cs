using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attach this script to something you want to destroy after timeUntilDestroy seconds
public class DestroyAfter : MonoBehaviour
{
    public float timeUntilDestroy = 5f;
    float timer;

    private void Start()
    {
        timer = timeUntilDestroy;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0f)
        {
            Destroy(gameObject);
        }
    }
}

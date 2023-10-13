using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEathSound : MonoBehaviour
{
    public AudioClip se;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathPoint"))
        {
            AudioSource.PlayClipAtPoint(se, transform.position);
        }
    }
}
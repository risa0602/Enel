using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBgm : MonoBehaviour
{
    public AudioClip se;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    /*public void PlayInteractionSound()
    {
        audioSource.PlayOneShot(interactionSound);
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("other collidion");
        if (other.CompareTag("Player"))
        {
            Debug.Log("OK");
            audioSource.PlayOneShot(se); // ジャンプ時の効果音を再生
            // AudioSource.PlayClipAtPoint(se, transform.position);
        }
    }
}

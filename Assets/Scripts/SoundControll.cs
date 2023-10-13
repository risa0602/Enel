using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControll : MonoBehaviour
{
    // Start is called before the first frame update
       public AudioClip se; 

 void OnCollisionEnter(Collision other)
  {
    AudioSource.PlayClipAtPoint(se,transform.position);
    Debug.Log("on");
  }
}

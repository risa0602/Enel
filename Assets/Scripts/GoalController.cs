using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    AudioSource _audio;
    void Start() 
    {
        _audio = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D other) {
        _audio.Play(); 
        
    }
}

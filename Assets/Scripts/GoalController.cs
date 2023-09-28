using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    float angle;

    public float maxHeight;
    public float flapVelocity;
    public float relateveVelocityX;
    public GameObject sprite;
    void Awake() 
    {
       rb2d = GetComponent<Rigidbody2D>();
       animator = sprite.GetComponent<Animator>(); 
    }
}

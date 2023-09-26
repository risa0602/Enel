using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    // Animator animator;
    // float angle;
    // bool isDead;

    // public float maxHeight;
    public float jumpVelocity;
    // public float relativeVelocityX;
    // public GameObject sprite;

    // public bool IsDead(){
        // return isDead;
    // }

    void Awake(){
       rb2d = GetComponent<Rigidbody2D>(); 
    //    animator = sprite.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") ){
            Jump();
        }    
        // ApplyAngle();
        // animator.SetBool("flap", angle >= 0.0f && !isDead);
    }

    public void Jump(){
        // if (isDead) return;
        if (rb2d.isKinematic) return;
            rb2d.velocity = new Vector2(0.0f, jumpVelocity);
    }

    // void ApplyAngle(){
        // float targetAngle;

        // if (isDead){
            // targetAngle = 180.0f;
        // } else{
            // targetAngle = Mathf.Atan2(rb2d.velocity.y, relativeVelocityX) * Mathf.Rad2Deg;
        // }
        
        // angle = Mathf.LerpAngle(angle, targetAngle, Time.deltaTime * 10.0f);
        // sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);
    // }

    // void OnCollisionEnter2D(Collision2D collision){
        // if (isDead) return;
        // Camera.main.SendMessage("Clash");
        // isDead = true;
    // }

    // public void SetSteerActive(bool active){
        // rb2d.isKinematic = !active;
    // }
}
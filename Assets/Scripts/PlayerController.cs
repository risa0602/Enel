using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public int life = 2;
    bool isJumping = false;
    SpriteRenderer rd;
    // BoxCollider2D bc2d;
    // bool isHit;
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

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //    animator = sprite.GetComponent<Animator>();
    }

    void Start()
    {
        rd = GetComponentInChildren<SpriteRenderer>();
        // bc2d = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isJumping && !(rb2d.velocity.y < -0.5f))
        {
            Jump();
        }
        // ApplyAngle();
        // animator.SetBool("flap", angle >= 0.0f && !isDead);
    }

    public int Life(){
        return life;
    }

    public void Jump()
    {
        // if (isDead) return;
        isJumping = true;
        // if (rb2d.isKinematic) return;
        rb2d.velocity = new Vector2(0.0f, jumpVelocity);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Enemyとぶつかった時にコルーチンを実行
        if (col.gameObject.tag == "Enemy")
        {
            life--;
            Debug.Log("life=" + life);
            StartCoroutine("Damage");
        }
    }

    IEnumerator Damage()
    {
        // 子オブジェクトを含む親オブジェクトを取得
        GameObject parentObject = GameObject.Find("Torokko,in,Enel");

        // 新しいレイヤーの名前を指定
        string newLayerName = "PlayerDamage";

        // 新しいレイヤーのIDを取得
        int newLayerID = LayerMask.NameToLayer(newLayerName);

        // 子オブジェクトを含む親オブジェクトのすべての子オブジェクトに対して処理を行う
        foreach(Transform child in parentObject.transform)
        {
            // 子オブジェクトのレイヤーを変更
            child.gameObject.layer = newLayerID;
        }
        /*
        //レイヤーをPlayerDamageに変更
        gameObject.layer = LayerMask.NameToLayer("PlayerDamage");
        */
        //while文を10回ループ
        
        int count = 10;
        while (count > 0)
        {
            //透明にする
            rd.material.color = new Color(1, 1, 1, 0);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            //元に戻す
            rd.material.color = new Color(1, 1, 1, 1);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            count--;
        }
        /*
        //レイヤーをPlayerに戻す
        gameObject.layer = LayerMask.NameToLayer("Player");
        */

        // 新しいレイヤーの名前を指定
        string oldLayerName = "Player";

        // 新しいレイヤーのIDを取得
        int oldLayerID = LayerMask.NameToLayer(oldLayerName);
        foreach(Transform child in parentObject.transform)
        {
            // 子オブジェクトのレイヤーを変更
            child.gameObject.layer = oldLayerID;
        }
        
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
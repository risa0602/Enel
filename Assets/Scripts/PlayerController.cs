using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public int life = 2;
    bool isJumping = false;
    // bool isEnemyOnJumping = false;
    SpriteRenderer rd;
    BoxCollider2D bc2d;
    float otherJumpHeight;

    [Header("ジャンプ力")] public float jumpVelocity;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rd = GetComponentInChildren<SpriteRenderer>();
        bc2d = GetComponentInChildren<BoxCollider2D>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isJumping && !(rb2d.velocity.y < -0.5f))
        {
            Jump();
        }
    }

    public int Life()
    {
        return life;
    }

    public void Jump()
    {
        isJumping = true;
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
            float halfScaleY = transform.lossyScale.y / 2.0f;
            float enemyHalfScaleY = col.transform.lossyScale.y / 2.0f;
            if (transform.position.y - (halfScaleY - 0.1f) >= col.transform.position.y + (enemyHalfScaleY - 0.1f))
            {
                //もう一度跳ねる
                ObjectCollision o = col.gameObject.GetComponent<ObjectCollision>();
                otherJumpHeight = o.boundHeight;
                o.playerStepOn = true;
                // isEnemyOnJumping = true;
                rb2d.velocity = new Vector2(0.0f, otherJumpHeight);
            }
            else
            {
                life--;
                Debug.Log("life=" + life);
                StartCoroutine("Damage");
            }
        }
        else if (col.gameObject.tag == "DeathPoint")
        {
            life -= 99999;//DeathPointに当たると99999ダメージ
            Debug.Log("life=" + life);
        }
        else if (col.gameObject.tag == "Recovery")
        {
            life++;
            Debug.Log("life=" + life);
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
        foreach (Transform child in parentObject.transform)
        {
            // 子オブジェクトのレイヤーを変更
            child.gameObject.layer = newLayerID;
        }

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

        //レイヤーをPlayerに戻す
        string oldLayerName = "Player";
        int oldLayerID = LayerMask.NameToLayer(oldLayerName);
        foreach (Transform child in parentObject.transform)
        {
            child.gameObject.layer = oldLayerID;
        }
    }
}
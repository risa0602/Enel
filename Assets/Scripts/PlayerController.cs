using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    SpriteRenderer rd;
    BoxCollider2D bc2d;
    public int life = 2;
    bool isJumping = false;
    // bool isEnemyOnJumping = false;
    [Header("ジャンプ力")] public float jumpVelocity;
    float otherJumpHeight;
    public Animator childanimatorEnel;
    public Animator childanimatorTorokko;
    public GameObject gameObjectToDisable;
    public GameObject gameObjectToEnable;
    public GameObject[] obToHide;
    public GameObject[] obToShow;
    public AudioClip jumpSound; // ジャンプの音声ファイル
    public AudioClip enemyOnJumpSound; // 敵を踏んだときの音声ファイル
    private AudioSource audioSource; // 効果音を再生するためのAudioSource
    public AudioClip Rs; // 敵を踏んだときの音声ファイル


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rd = GetComponentInChildren<SpriteRenderer>();
        bc2d = GetComponentInChildren<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isJumping && !(rb2d.velocity.y < -0.5f))
        {
            Jump();
        }
        if (life <= 0)
        {
            DisableGameObject();
        }
        else
        {
            EnableGameObject();
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
        childanimatorEnel.SetBool("jump", true);
        childanimatorTorokko.SetBool("jump", true);
        audioSource.PlayOneShot(jumpSound); // ジャンプ時の効果音を再生
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            isJumping = false;
            childanimatorEnel.SetBool("jump", false);
            childanimatorTorokko.SetBool("jump", false);
        }
    }
    void ReturnToTitleWithoutAnimation()
    {
        //ゲームオブジェクトを無効にする
        if (gameObjectToDisable != null)
        {
            gameObjectToDisable.SetActive(false);
        }
        //タイトルシーンに移行
        SceneManager.LoadScene("TitleCo");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Truck"))
        {
            foreach (GameObject obj in obToHide)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }
            foreach (GameObject obj in obToShow)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                }
            }
        }
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
                audioSource.PlayOneShot(enemyOnJumpSound);
            }
            else
            {
                life--;
                Debug.Log("life=" + life);
                Camera.main.SendMessage("Clash");
                StartCoroutine("Damage");
            }
        }
        else if (col.gameObject.tag == "SuperEnemy")
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
                audioSource.PlayOneShot(enemyOnJumpSound);
            }
            else
            {
                life -= 99999;
                Debug.Log("life=" + life);
                Camera.main.SendMessage("Clash");
                StartCoroutine("Damage");
            }
        }
        else if (col.gameObject.tag == "CantJumpEnemy")
        {
            life--;
            Debug.Log("life=" + life);
            Camera.main.SendMessage("Clash");
            StartCoroutine("Damage");
        }
        else if (col.gameObject.tag == "DeathPoint")
        {
            life -= 99999;//DeathPointに当たると99999ダメージ
            Debug.Log("life=" + life);
            Camera.main.SendMessage("Clash");
            ReturnToTitleWithoutAnimation();//DeathPointで死んだときvoid ReturnToTitleを呼び出す
        }
        else if (col.gameObject.tag == "Truck")
        {
            life -= 99999;//DeathPointに当たると99999ダメージ
            Debug.Log("life=" + life);
            Camera.main.SendMessage("Clash");
        }
        else if (col.gameObject.tag == "Recovery")
        {
            audioSource.PlayOneShot(Rs);
            if (life < 2)
            {
                life++;
                Debug.Log("life=" + life);
            }
        }
    }
    //GameObjectを無効にするメソッド
    void DisableGameObject()
    {
        if (gameObjectToDisable != null)
        {
            gameObjectToDisable.SetActive(false);
        }
        if (gameObjectToEnable != null)
        {
            gameObjectToEnable.SetActive(true);
        }
    }
    //GameObjectを有効にするメソッド
    void EnableGameObject()
    {
        if (gameObjectToDisable != null)
        {
            gameObjectToDisable.SetActive(true);
        }
        if (gameObjectToEnable != null)
        {
            gameObjectToEnable.SetActive(false);
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

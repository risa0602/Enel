using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropDown : MonoBehaviour
{
    [Header("落ち始めるx座標")]public float fallPosition = 5.0f;
    [Header("落下速度")]public float fallSpeed = 5.0f; // 落下速度

    void Start()
    {
        // スクリプトがアタッチされた瞬間は物理挙動を無効化
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    void Update()
    {
        if (transform.position.x <= fallPosition)
        {
            // 上から落ちてくる処理
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; // Dynamicに設定して物理挙動を有効化
            GetComponent<Rigidbody2D>().velocity = Vector2.down * fallSpeed; // 落下速度を適用
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
     [Header("これを踏んだ時のプレイヤーが跳ねる高さ(25が基準)")] public float boundHeight;

     /// <summary>
     /// このオブジェクトをプレイヤーが踏んだかどうか
     /// </summary>
     [HideInInspector] public bool playerStepOn;

     void Update()
     {
          if (playerStepOn)
          {
               transform.rotation = Quaternion.Euler(0, 0, 180); // 180度回転
               GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; // ダイナミックな物理挙動に変更
               GetComponent<Collider2D>().isTrigger = true; // トリガーコライダーに変更
          }
     }
}

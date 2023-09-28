using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
     [Header("これを踏んだ時のプレイヤーが跳ねる高さ(30が基準)")] public float boundHeight;

     /// <summary>
     /// このオブジェクトをプレイヤーが踏んだかどうか
     /// </summary>
     [HideInInspector] public bool playerStepOn;

     void Update()
     {
          if (playerStepOn)
          {
               Destroy(gameObject);
          }
     }
}

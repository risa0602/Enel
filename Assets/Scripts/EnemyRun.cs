using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : MonoBehaviour
{
    [Header("動き始めるx座標")]public float movePosition = 15.0f;

    [Header("敵が向かってくる速度")] public float speed = 1.0f;
    void Update()
    {
        if(transform.position.x <= movePosition)
        {
         transform.Translate(-1 * speed * Time.deltaTime,0,0);
        }
    }
}

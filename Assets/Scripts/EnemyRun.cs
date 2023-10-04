using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : MonoBehaviour
{
    [Header("敵が向かってくる速度")] public float speed = 1.0f;
    void Update()
    {
        if(transform.position.x <= 15)
        {
         transform.Translate(-1 * speed * Time.deltaTime,0,0);
        }
    }
}

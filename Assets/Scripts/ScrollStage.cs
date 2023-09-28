using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollStage : MonoBehaviour
{
    public float speed = 8.0f;
    void Update()
    {
        transform.Translate(-1 * speed * Time.deltaTime,0,0);
        if(transform.position.x <= -20)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollStage : MonoBehaviour
{
    public float speed = 1.0f;
    public float startPosition;
    public float endPosition;
    void Update()
    {
        transform.Translate(-1 * speed * Time.deltaTime,0,0);
        if(transform.position.x <= endPosition)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollStage : MonoBehaviour
{
    public float speed = 8.0f;
    bool isScrolling = true;

    void Update()
    {
        if (isScrolling)
        {
            transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
            if (transform.position.x <= -40)
            {
                Destroy(gameObject);
            }
            if (transform.position.y <= -60)
            {
                Destroy(gameObject);
            }
        }
    }

    public void StopScrolling()
    {
        isScrolling = false;
    }
}

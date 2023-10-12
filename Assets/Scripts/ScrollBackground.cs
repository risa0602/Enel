using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float speed = 8.0f;
    public float startPosition = 16;
    public float endPosition = -20;
    bool isScrolling = true;

    void Update()
    {
        if (isScrolling)
        {
            transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

            if (transform.position.x <= endPosition) ScrollEnd();
        }
    }

    void ScrollEnd()
    {
        float diff = transform.position.x - endPosition;
        Vector3 restartPosition = transform.position;
        restartPosition.x = startPosition + diff;
        transform.position = restartPosition;

        SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
    }

    public void StopScrolling()
    {
        isScrolling = false;
    }
}

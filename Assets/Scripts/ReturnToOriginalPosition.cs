using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToOriginalPosition : MonoBehaviour
{
    [Header("x座標が〇〇ずれたら発動")]public float xThreshold = 0.1f; // ずれるx座標の閾値
    [Header("元の位置に戻る速度")]public float returnSpeed = 5.0f; // 元の位置に戻る速度

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // 現在位置と元の位置の差が閾値を超えたら元の位置に戻す
        if (Mathf.Abs(transform.position.x - originalPosition.x) > xThreshold)
        {
            float step = returnSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, step);
        }
    }
}
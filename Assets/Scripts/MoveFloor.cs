using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    [Header("上下移動する距離")]public float moveDistance = 3.0f; // 移動する総距離
    [Header("移動速度")]public float moveSpeed = 2.0f;   // 移動速度

    private Vector3 initialPosition;
    private float targetPositionY;
    private int moveDirection = 1; // 移動方向 (1: 上方向, -1: 下方向)

    void Start()
    {
        initialPosition = transform.position;
        targetPositionY = initialPosition.y + moveDistance;
    }

    void Update()
    {
        float newY = transform.position.y + moveDirection * moveSpeed * Time.deltaTime;

        // 目標位置に達したら反転
        if ((moveDirection == 1 && newY >= targetPositionY) ||
            (moveDirection == -1 && newY <= initialPosition.y))
        {
            moveDirection *= -1; // 方向を反転
        }

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
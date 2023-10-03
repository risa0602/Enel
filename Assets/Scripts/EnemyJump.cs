using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    [Header("自動でジャンプしている高さ")]public float jumpForce = 5f; // ジャンプの力
    [Header("ジャンプの間隔")]public float jumpInterval = 2f; // ジャンプの間隔

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Jump", 0f, jumpInterval);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HierarchyOff : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Recovery"))
        {
            // "Recovery" タグのオブジェクトに当たったら削除する
            Destroy(collision.gameObject);
        }
    }
}

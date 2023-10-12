using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 衝突したオブジェクトが "Goal" タグを持つ場合
            // "ScrollBackground" スクリプトを持つオブジェクトを停止
            
            Debug.Log("ok");
            ScrollBackground[] scrollBackgrounds = FindObjectsOfType<ScrollBackground>();
            foreach (ScrollBackground scrollBackground in scrollBackgrounds)
            {
                scrollBackground.StopScrolling();
            }

            // "ScrollStage" スクリプトを持つオブジェクトを停止
            ScrollStage[] scrollStages = FindObjectsOfType<ScrollStage>();
            foreach (ScrollStage scrollStage in scrollStages)
            {
                scrollStage.StopScrolling();
            }
    }
}

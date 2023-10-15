using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static bool stage1Cleared = false;
    public static bool stage2Cleared = false;
    public static bool stage3Cleared = false;

    void Start()
    {
        // セーブデータの読み込み
        stage1Cleared = PlayerPrefs.GetInt("stage1Cleared", 0) == 1;
        stage2Cleared = PlayerPrefs.GetInt("stage2Cleared", 0) == 1;
        stage3Cleared = PlayerPrefs.GetInt("stage3Cleared", 0) == 1;
    }

    // ゲームプレイ中にクリア状態が変化したら呼ぶメソッド
    public static void SaveProgress()
    {
        PlayerPrefs.SetInt("stage1Cleared", stage1Cleared ? 1 : 0);
        PlayerPrefs.SetInt("stage2Cleared", stage2Cleared ? 1 : 0);
        PlayerPrefs.SetInt("stage3Cleared", stage3Cleared ? 1 : 0);
        PlayerPrefs.Save();
    }
    public static void ResetClearStatus()
    {
        stage1Cleared = false;
        stage2Cleared = false;
        stage3Cleared = false;
    }
}
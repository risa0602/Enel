using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSaveData : MonoBehaviour
{
    public void ResetData()
    {
        PlayerPrefs.DeleteAll(); // すべてのセーブデータを削除
        StageManager.ResetClearStatus();
        Debug.Log("セーブデータがリセットされました。");
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    public static Material previousSkybox; // 前のシーンのSkyboxを保持する変数

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // シーン切り替え時にオブジェクトを破棄しないように設定
    }
}
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public AudioSource audioSource; // 効果音を再生するためのAudioSource

    // ボタンがクリックされた際に呼び出される関数
    public void OnButtonClick()
    {
        // 効果音を再生する
        audioSource.Play();
    }
}

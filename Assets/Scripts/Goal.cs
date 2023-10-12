using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public AudioClip se;
    AudioSource audioSource; // 効果音を再生するためのAudioSource
    AudioSource mainCameraAudio;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // MainCameraにアタッチされたAudioSourceを取得
        mainCameraAudio = Camera.main.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ok");

        mainCameraAudio.Stop();
        audioSource.PlayOneShot(se);

        // "ScrollBackground" スクリプトを持つオブジェクトを停止
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

        Invoke("ReturnToTitle", 2.0f);
    }

    void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleCo");
    }

}

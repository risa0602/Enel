using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button stage1Button;
    public Button stage2Button;
    public Button stage3Button;

    public Image stage1ClearMark;
    public Image stage2ClearMark;
    public Image stage3ClearMark;
    public Text credit;

    public Image stage1OnEnel;
    public Image stage2OnEnel;
    public Image stage3OnEnel;

    void Start()
    {
        stage1Button.onClick.AddListener(LoadStage1);
        stage2Button.onClick.AddListener(LoadStage2);
        stage3Button.onClick.AddListener(LoadStage3);

        // クリア状態に応じてボタンの有効/無効を切り替える
        stage2Button.interactable = StageManager.stage1Cleared;
        stage3Button.interactable = StageManager.stage2Cleared;

        // クリアマークの表示/非表示を設定
        stage1ClearMark.enabled = StageManager.stage1Cleared;
        stage2ClearMark.enabled = StageManager.stage2Cleared;
        stage3ClearMark.enabled = StageManager.stage3Cleared;
        credit.enabled = StageManager.stage3Cleared;


        stage1OnEnel.enabled = !StageManager.stage1Cleared;
        stage2OnEnel.enabled = StageManager.stage1Cleared;
        stage3OnEnel.enabled = StageManager.stage2Cleared;
        /*
        if (StageManager.stage2Cleared)
        {
            stage2OnEnel.enabled = false;
            stage3OnEnel.enabled = StageManager.stage2Cleared;
        }
        */
    }

    void LoadStage1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Stage1");
    }

    void LoadStage2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Stage2");
    }

    void LoadStage3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Stage3");
    }
}
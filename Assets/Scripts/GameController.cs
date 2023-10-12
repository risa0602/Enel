using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    enum State
    {
        Playing,
        GameOver,
        Gameclear
    }
    State state;
    public PlayerController pl;
    public LifePanel lifePanel;
    AudioSource mainCameraAudio;

    void Start()
    {
        mainCameraAudio = Camera.main.GetComponent<AudioSource>();
    }

    void Update()
    {
        lifePanel.UpdateLife(pl.life);
        if (pl.life <= 0)
        {
            if (state != State.GameOver)
            {
                state = State.GameOver;
                GameOver();
            }
        }
        else
        {
            if (state != State.Playing)
            {
                state = State.Playing;
            }
        }
    }
    void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleCo");
    }
    void GameOver()
    {
        state = State.GameOver;
        mainCameraAudio.Stop();
        ScrollStage[] scrollStages = FindObjectsOfType<ScrollStage>();
        foreach (ScrollStage so in scrollStages)
        {
            so.enabled = false;
        }
        ScrollBackground[] scrollBackgrounds = FindObjectsOfType<ScrollBackground>();
        foreach (ScrollBackground sb in scrollBackgrounds)
        {
            sb.enabled = false;
        }
        enabled = false;
        Invoke("ReturnToTitle", 1.0f);
    }

}

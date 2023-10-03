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
        GameOver
    }
    State state;
    public PlayerController pl;
    public LifePanel lifePanel;
    void Update()
    {
        lifePanel.UpdateLife(pl.life);
        if(pl.life <= 0)
        {
            if(state != State.GameOver)
            {
                state=State.GameOver;
                GameOver();
            } 
        }
        else
        {
            if(state != State.Playing)
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
        ScrollStage[] scrollStages = FindObjectsOfType<ScrollStage>();
        foreach (ScrollStage so in scrollStages)
        {
            so.enabled = false; 
        }
            enabled = false;
            Invoke("ReturnToTitle",1.0f);
    }
}

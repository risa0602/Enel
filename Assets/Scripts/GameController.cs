using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerController pl;
    public LifePanel lifePanel;
    void Update()
    {
        lifePanel.UpdateLife(pl.life);
        if(pl.life <= 0)
        {
            enabled = false;
            Invoke("ReturunToTitle",2.0f);
        }
    }
    void ReturnTotitle()
    {
        SceneManager.LoadScene("Title");
    }
}

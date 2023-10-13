using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToStage2 : MonoBehaviour
{
    public void  OnStatButtonClicked()
    {
        SceneManager.LoadScene("Stage2");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToStage3 : MonoBehaviour
{
    public void  OnStatButtonClicked()
    {
        SceneManager.LoadScene("Stage3");
    }
}

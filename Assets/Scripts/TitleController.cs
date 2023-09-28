using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController: MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCo : MonoBehaviour
{
    public void  OnStatButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }
}

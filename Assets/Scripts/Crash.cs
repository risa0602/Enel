using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    public GameObject gameObjectToDisable;
    public GameObject gameObjectToEnable;

    void Start()
    {
    }
    void Update()
    {
    }
    void ReturnToTitleWithoutAnimation()
    {
        //タイトルシーンに移行
        SceneManager.LoadScene("TitleCo");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Truck")
        {
            ReturnToTitleWithoutAnimation();//DeathPointで死んだときvoid ReturnToTitleを呼び出す
        }
    }
    //GameObjectを無効にするメソッド
    void DisableGameObject()
    {
        if(gameObjectToDisable != null)
        {
            gameObjectToDisable.SetActive(false);
        }
        if(gameObjectToEnable != null)
        {
            gameObjectToEnable.SetActive(true);
        }
    }
    //GameObjectを有効にするメソッド
    void EnableGameObject()
    {
        if(gameObjectToDisable != null)
        {
            gameObjectToDisable.SetActive(true);
        }
        if(gameObjectToEnable != null)
        {
            gameObjectToEnable.SetActive(false);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaniController : MonoBehaviour
{
public GameObject wani;
    void OnTriggerExit2D(Collider2D other) 
    {
    Debug.Log("ok");
       wani.SetActive(true);
    }
}

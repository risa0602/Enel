using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaniMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < 5.2f){
        transform.Translate(Vector3.up * 3f * Time.deltaTime );

        }
    }
}

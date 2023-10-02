using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public void ResetToOriginalPosition(){
        transform.localPosition = new Vector2(-0.22f, 2.28f);
    }
}

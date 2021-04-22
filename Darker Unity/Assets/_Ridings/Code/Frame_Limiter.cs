using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame_Limiter : MonoBehaviour
{
    public int frameCap;

    private void Start()
    {
        Application.targetFrameRate = frameCap;
    }

}

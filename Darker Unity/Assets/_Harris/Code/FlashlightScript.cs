using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{

    public Light flashlight;

    public bool on = true;
    void Start()
    {
        on = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(on == true)
            {
                flashlight.enabled = false;
                on = false;
            }
            else
            {
                flashlight.enabled = true;
                on = true;
            }
        }
    }
}

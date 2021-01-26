using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Fire : MonoBehaviour
{

    public GameObject gun;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            gun.GetComponent<Animator>().Play("Gun_Fire_Anim");
        }
        else
        {
            gun.GetComponent<Animator>().StopPlayback();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healies : MonoBehaviour
{
    public GameObject FPSPlayer;

    public void Interaction()
    {
        FPSPlayer.GetComponent<HealthManager>().health += 50;
        Destroy(this.gameObject);
    }
}

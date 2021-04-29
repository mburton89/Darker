using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadeDie : MonoBehaviour
{
    HealthManager healthManager;
    private float health;
    public GameObject deadShade;

    private void Update()
    {
        health = healthManager.health;

        if (health <= 0)
        {
            Instantiate(deadShade, gameObject.transform);
        }
    }

}

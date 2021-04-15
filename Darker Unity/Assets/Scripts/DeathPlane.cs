using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.GetComponent("HealthManager") != null))
        {
            other.gameObject.GetComponent<HealthManager>().health -= 25;
            //other.gameObject.GetComponent<HealthManager>().Instakill();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Transform startPosition;

    private void Awake()
    {
        startPosition = gameObject.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if ((collision.gameObject.GetComponent("HealthManager") != null))
        {
            collision.gameObject.GetComponent<HealthManager>().health -= 10;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if ((collider.gameObject.GetComponent("AIScript") != null))
        {
            collider.SendMessage("FiringLocation");
        }
        Destroy(gameObject);
    }
}

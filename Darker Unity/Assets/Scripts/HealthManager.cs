using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameObject entity;
    public int health;
    public Text healthDisplay;
    public Image viewColor;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            entity.SetActive(false);
        }
        if (entity.name == "FPSPlayer")
        {
            healthDisplay.text = "HEALTH: " + health.ToString();
            if (health <= 0)
            {
                var tempColor = viewColor.color;
                tempColor.a = 1f;
                viewColor.color = tempColor;
            }
            else if (health <= 25)
            {
                var tempColor = viewColor.color;
                tempColor.a = 0.35f;
                viewColor.color = tempColor;
            }
            else if (health <= 50)
            {
                var tempColor = viewColor.color;
                tempColor.a = 0.15f;
                viewColor.color = tempColor;
            }
            else if (health <= 75)
            {
                var tempColor = viewColor.color;
                tempColor.a = 0.05f;
                viewColor.color = tempColor;
            }
            else if (health <= 100)
            {
                var tempColor = viewColor.color;
                tempColor.a = 0f;
                viewColor.color = tempColor;
            }
        }
    }

    public void Instakill()
    {
        health = 0;
    }
}

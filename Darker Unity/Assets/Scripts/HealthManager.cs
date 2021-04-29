using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public GameObject entity;
    public int health;
    public Text healthDisplay;
    public Image viewColor;
    public Camera deathCamera;
    public GameObject deathMenu;

    public GameObject deadShade;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (entity.name == "FPSPlayer")
        {
            /*if (Time.timeScale == 0)
            {
                healthDisplay.enabled = false;
            }
            else
            {
                healthDisplay.enabled = true;
            }
            healthDisplay.text = "HEALTH: " + health.ToString();*/
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
        if (health <= 0)
        {
            if (entity.name == "FPSPlayer")
            {
                //healthDisplay.text = "";
                Cursor.lockState = CursorLockMode.Confined;
                deathCamera.enabled = true;
                deathMenu.SetActive(true);
            }
            //entity.SetActive(false);

            if (entity.name == "Shade")
            {
                KillShade();
            }
        }
    }

    public void KillShade()
    {
        Instantiate(deadShade, entity.transform.position + transform.up * 1.5f, entity.transform.rotation, null);
        Destroy(gameObject);
    }

    public void Instakill()
    {
        health = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;
    public bool startLocked = true;

    public GameObject menu;

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                isPaused = false;
                menu.SetActive(false);
                if (startLocked == true) Cursor.lockState = CursorLockMode.Locked;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                isPaused = true;
                menu.SetActive(true);
                if (Cursor.lockState == CursorLockMode.Confined) startLocked = false; else startLocked = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        menu.SetActive(false);
        if (startLocked == true) Cursor.lockState = CursorLockMode.Locked;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Main_Menu");
        Time.timeScale = 1;
    }
}

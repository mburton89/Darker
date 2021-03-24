using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalScript : MonoBehaviour
{
    public GameObject JournalUI;
    public Image contentImage;
    public Text contentText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                JournalUI.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                contentImage.enabled = false;
                contentText.enabled = false;
            }
        }
        else if (Cursor.lockState == CursorLockMode.Confined)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                JournalUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}

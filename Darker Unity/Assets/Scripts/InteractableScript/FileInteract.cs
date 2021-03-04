using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileInteract : MonoBehaviour
{
    //public GameObject file;
    public GameObject ImageUI;
    public Sprite img;
    public Image ImageCanvas;

    public bool openUI = false;


    // Update is called once per frame
    void Update()
    {
        if (openUI == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Cursor.lockState = CursorLockMode.Locked;
                openUI = false;
                ImageUI.SetActive(false);
            }
        }
    }

    public void Interaction()
    {
        openUI = true;
        //ImageCanvas.rectTransform.sizeDelta = new Vector2(img.textureRect.height, img.textureRect.width);
        ImageCanvas.sprite = img;

        Cursor.lockState = CursorLockMode.Confined;
        ImageUI.SetActive(true);
    }
}

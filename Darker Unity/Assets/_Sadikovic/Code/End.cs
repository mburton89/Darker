﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider gameObjectInformation){
        if (gameObjectInformation.gameObject.name == "FPSPlayer") {
            Debug.Log("Collision Detected");
            SceneManager.LoadScene("Credits");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    
}

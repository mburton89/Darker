﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestDoorInteract : MonoBehaviour
{
    //Linked door gameobject
    public GameObject Door;

    //keypad internal booleans
    public bool switched = false;
    public bool locked = true;
    public bool openUI = false;

    //keycode entry variables
    public string padCode;
    public string entry;

    //keypad external variables
    public GameObject KeypadUI;
    public Text input;

    void Update()
    {
        if (openUI == true)
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.Locked;
                openUI = false;
                KeypadUI.SetActive(false);
            }
            if (locked && entry.Length < padCode.Length)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    entry += "1";
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    entry += "2";
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    entry += "3";
                }
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    entry += "4";
                }
                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    entry += "5";
                }
                if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    entry += "6";
                }
                if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    entry += "7";
                }
                if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    entry += "8";
                }
                if (Input.GetKeyDown(KeyCode.Alpha9))
                {
                    entry += "9";
                }
                if (Input.GetKeyDown(KeyCode.Alpha0))
                {
                    entry += "0";
                }
            }
            input.text = entry;
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (entry == padCode)
                {
                    locked = false;
                    Debug.Log("Access Granted");
                    Cursor.lockState = CursorLockMode.Locked;
                    openUI = false;
                    KeypadUI.SetActive(false);
                }
                else
                {
                    entry = "";
                }
            }
        }
    }

    //function called when player interacts with the gameobject
    public void Interaction()
    {
        if (locked)
        {
            Cursor.lockState = CursorLockMode.Confined;
            openUI = true;
            Debug.Log("Access Denied");
            entry = "";
            input.text = entry;
            KeypadUI.SetActive(true);
        } 
        else
        {
            if (!switched)
            {
                Door.transform.Translate(-8f, 0f, 0f);
                switched = true;
            }
            else if (switched)
            {
                Door.transform.Translate(8f, 0f, 0f);
                switched = false;
            }
        }
    }
    
    //code for mouse inputs
    public void OnClickMouse(Button button)
    {
        if (openUI)
        {
            string name = button.name;
            if (name == "Button (*)")
            {
                Cursor.lockState = CursorLockMode.Locked;
                openUI = false;
                KeypadUI.SetActive(false);
            }
            if (locked && entry.Length < padCode.Length)
            {
                if (name == "Button (1)")
                {
                    entry += "1";
                }
                if (name == "Button (2)")
                {
                    entry += "2";
                }
                if (name == "Button (3)")
                {
                    entry += "3";
                }
                if (name == "Button (4)")
                {
                    entry += "4";
                }
                if (name == "Button (5)")
                {
                    entry += "5";
                }
                if (name == "Button (6)")
                {
                    entry += "6";
                }
                if (name == "Button (7)")
                {
                    entry += "7";
                }
                if (name == "Button (8)")
                {
                    entry += "8";
                }
                if (name == "Button (9)")
                {
                    entry += "9";
                }
                if (name == "Button (0)")
                {
                    entry += "0";
                }
            }
            if (name == "Button (#)")
            {
                if (entry == padCode)
                {
                    locked = false;
                    Debug.Log("Access Granted");
                    Cursor.lockState = CursorLockMode.Locked;
                    openUI = false;
                    KeypadUI.SetActive(false);
                }
                else
                {
                    entry = "";
                }
            }
        }
    }
    
}
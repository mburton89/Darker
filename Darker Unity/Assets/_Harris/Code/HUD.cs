using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public GameObject Inventory;

    public GameObject MessagePanel;

    public List<Image> outlines;
    private int _index;

    void Awake()
    {
        Instance = this;

        _index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.mouseScrollDelta)
        print("Scroll wheel: " + Input.mouseScrollDelta);

        if (Input.mouseScrollDelta.y == 1 || Input.mouseScrollDelta.y == -1)
        {
            ShowMenu();
        }

        if (Input.mouseScrollDelta.y == 1 && _index < outlines.Count)
        {
            _index++;
        }
        else if (Input.mouseScrollDelta.y == -1 && _index > 0)
        {
            _index--;
        }
    }

    void ShowMenu()
    {
        StopCoroutine(nameof(DelayHide));
        StartCoroutine(nameof(DelayHide));
    }

    private IEnumerator DelayHide()
    {
        Inventory.SetActive(true);
        yield return new WaitForSeconds(3);
        Inventory.SetActive(false);
    }

    public void OpenInventory(string text)
    {
        MessagePanel.SetActive(true);
    }

    public void CloseInventory(string text)
    {
        MessagePanel.SetActive(false);
    }


    void Start()
    {
        
    }
}

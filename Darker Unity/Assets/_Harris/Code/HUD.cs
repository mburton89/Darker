using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject container;

    public List<Image> outlines;
    void Start()
    {
        
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
    }

    void ShowMenu()
    {
        StopCoroutine(nameof(DelayHide));
        StartCoroutine(nameof(DelayHide));
    }

    private IEnumerator DelayHide()
    {
        container.SetActive(true);
        yield return new WaitForSeconds(3);
        container.SetActive(false);
    }
}

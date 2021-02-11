using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject container;

    public GameObject MessagePanel;

    public List<Image> outlines;
    private int _index;

    void Awake()
    {
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
        container.SetActive(true);
        yield return new WaitForSeconds(3);
        container.SetActive(false);
    }

    public void OpenMessagePanel(string text)
    {
        MessagePanel.SetActive(true);
    }

    public void CloseMessagePanel(string text)
    {
        MessagePanel.SetActive(false);
    }
}

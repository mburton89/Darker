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
    public GameObject _currentOutline;
    public int _index;
    public GameObject Reticle;

    [SerializeField] private GameObject _FlashlightThumbnail;
    [SerializeField] private GameObject _FirstAidThumbnail;
    [SerializeField] private GameObject _PistolThumbnail;

    [SerializeField] private GameObject _FlashlightInactiveIndicator;
    [SerializeField] private GameObject _FirstAidInactiveIndicator;
    [SerializeField] private GameObject _PistolInactiveIndicator;

    void Awake()
    {
        Instance = this;

        _index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.mouseScrollDelta)
        //print("Scroll wheel: " + Input.mouseScrollDelta);

        if (Input.mouseScrollDelta.y == 1 || Input.mouseScrollDelta.y == -1)
        {
            ShowMenu();
        }

        if (Input.mouseScrollDelta.y == 1 && _index < outlines.Count - 1)
        {
            _index++;
            ShowActiveOutline();
        }
        else if (Input.mouseScrollDelta.y == -1 && _index > 0)
        {
            _index--;
            ShowActiveOutline();
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

    void ShowActiveOutline()
    {
        if (_currentOutline != null)
        {
            _currentOutline.SetActive(false);
        }
        outlines[_index].gameObject.SetActive(true);
        _currentOutline = outlines[_index].gameObject;
    }

    public void OpenInventory(string text)
    {
        MessagePanel.SetActive(true);
    }

    public void CloseInventory(string text)
    {
        MessagePanel.SetActive(false);
    }

    public void HandleItemCollected(Collectible.CollectibleType collectibleType)
    {
        if (collectibleType == Collectible.CollectibleType.Flashlight)
        {
            _FlashlightInactiveIndicator.SetActive(false);
        }
        else if (collectibleType == Collectible.CollectibleType.FirstAidKit)
        {
            _FirstAidInactiveIndicator.SetActive(false);
        }
        else if (collectibleType == Collectible.CollectibleType.Pistol)
        {
            _PistolThumbnail.SetActive(false);
        }
    }
}

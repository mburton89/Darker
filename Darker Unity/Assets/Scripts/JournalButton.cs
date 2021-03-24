using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalButton : MonoBehaviour
{
    public Image ImageUI;
    public Sprite content;
    
    public void ButtonClick()
    {
        ImageUI.enabled = true;
        ImageUI.sprite = content;
    }
}

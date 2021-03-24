using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType
    {
        Flashlight,
        FirstAidKit,
        Knife,
        Pistol,
        Shotgun
    }

    public CollectibleType activeCollectibleType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HUD.Instance.MessagePanel.SetActive(true);
            other.GetComponent<PlayerMovement>().activeCollectible = this;
        }
        

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            HUD.Instance.MessagePanel.SetActive(false);
            other.GetComponent<PlayerMovement>().activeCollectible = null;
        }
    }
    public void GetCollected()
    {
        Destroy(gameObject);
        HUD.Instance.HandleItemCollected(activeCollectibleType);
        HUD.Instance.MessagePanel.SetActive(false);
    } 
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation_Manager : MonoBehaviour
{
    public Animator animator;
    public GameObject pistol;
    public GameObject flashlight;
    private int pistolFiredID;
    private int nearInteractableID;
    private int pistolEquippedID;
    private int flashlightEquippedID;
    private int isReloadingID;
    private void Start()
    {
        pistolFiredID = Animator.StringToHash("pistolFired");
        nearInteractableID = Animator.StringToHash("nearInteractable");
        pistolEquippedID = Animator.StringToHash("pistolEquipped");
        flashlightEquippedID = Animator.StringToHash("flashlightEquipped");
        isReloadingID = Animator.StringToHash("isReloading");

        animator.SetBool(pistolEquippedID, true);
        animator.SetBool(nearInteractableID, false);
        animator.SetBool(pistolFiredID, false);
        animator.SetBool(flashlightEquippedID, false);
        animator.SetBool(isReloadingID, false);
    }

    void Update()
    {
        if (animator.GetBool(pistolEquippedID) == true)
        {
            pistol.SetActive(true);
            flashlight.SetActive(false);
        }


        if (animator.GetBool(flashlightEquippedID) == true)
        {
            flashlight.SetActive(true);
            pistol.SetActive(false);
        }


        if (Input.GetButtonDown("Fire"))
        {
            FirePistol();
        }

        else
        {
            animator.SetBool(pistolFiredID, false);
        }

        if (Input.GetButtonDown("Reload"))
        {
            ReloadPistol();
        }

        else
        {
            animator.SetBool(isReloadingID, false);
        }
    }
    
    void FirePistol()
    {
        animator.SetBool(pistolFiredID, true);
    }

    void ReloadPistol()
    {
        animator.SetBool(isReloadingID, true);
    }

}

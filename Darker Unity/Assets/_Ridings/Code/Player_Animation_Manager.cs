using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation_Manager : MonoBehaviour
{
    public Animator animator;
    public GameObject pistol;
    public GameObject muzzleFlash;
    public GameObject flashlight;

    private int pistolFiredID;
    private int nearInteractableID;
    private int pistolEquippedID;
    private int flashlightEquippedID;
    private int isReloadingID;

    private float fireCooldown;

    private void Start()
    {
        //Access animation parameters directly through their ID
        pistolFiredID = Animator.StringToHash("pistolFired");
        nearInteractableID = Animator.StringToHash("nearInteractable");
        pistolEquippedID = Animator.StringToHash("pistolEquipped");
        flashlightEquippedID = Animator.StringToHash("flashlightEquipped");
        isReloadingID = Animator.StringToHash("isReloading");

        //Parameter default states
        animator.SetBool(pistolEquippedID, true);
        animator.SetBool(nearInteractableID, false);
        animator.SetBool(pistolFiredID, false);
        animator.SetBool(flashlightEquippedID, false);
        animator.SetBool(isReloadingID, false);

        //Initialize fire cooldown
        fireCooldown = 0;
    }

    void Update()
    {
        //Fire cooldown timer
        if (fireCooldown > 0)
        {
            fireCooldown = fireCooldown - 0.1f;
        }

        //Pistol Equipped?
        if (animator.GetBool(pistolEquippedID) == true)
        {
            pistol.SetActive(true);
            flashlight.SetActive(false);
        }

        //Flashlight Equipped?
        if (animator.GetBool(flashlightEquippedID) == true)
        {
            flashlight.SetActive(true);
            pistol.SetActive(false);
        }

        //Fire Pistol
        if (Input.GetButtonDown("Fire") && fireCooldown <= 0)
        {
            FirePistol();
        }

        else
        {
            animator.SetBool(pistolFiredID, false);
        }

        //Reload Pistol
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
        fireCooldown += 1.5f;
        animator.SetBool(pistolFiredID, true);
        StartCoroutine("MuzzleFlash");
    }

    void ReloadPistol()
    {
        animator.SetBool(isReloadingID, true);
    }

    IEnumerator MuzzleFlash()
    {

        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        muzzleFlash.SetActive(false);
    }

}

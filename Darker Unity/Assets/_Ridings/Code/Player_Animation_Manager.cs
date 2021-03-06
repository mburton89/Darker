﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Animation_Manager : MonoBehaviour
{
    public PlayerRaycasting playerRaycasting;
    public HUD hud;
    public CharacterController characterController;

    public GameObject footstepControllerPrefab;

    public Animator animator;
    public GameObject pistol;
    public GameObject muzzleFlash;
    public GameObject gunshotPrefab;
    public GameObject reloadPrefab;
    public GameObject flashlight;
    public Rigidbody projectile;
    public Camera playerCamera;

    public int magazineSize;
    public int bulletsInMagazine;
    public int ammoClips;
    public float projectileSpeed;

    public Image bulletOne;
    public Image bulletTwo;
    public Image bulletThree;
    public Image bulletFour;
    public Image bulletFive;
    public Image bulletSix;
    public Image bulletSeven;
    public Image bulletEight;

    private int pistolFiredID;
    private int nearInteractableID;
    private int pistolEquippedID;
    private int flashlightEquippedID;
    private int isReloadingID;
    private bool reloading;

    private float fireCooldown;

    private Collider target;

    public int indexNumber;

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

        //Initialize Ammunition
        bulletsInMagazine = magazineSize;

        //Starting Ammo Clips
        ammoClips = 1;

    }

    void Update()
    {
        //print(indexNumber);
        indexNumber = hud._index;
        if (indexNumber == 0)
        {
            animator.SetBool(flashlightEquippedID, true);
            animator.SetBool(pistolEquippedID, false);
            HUD.Instance.Reticle.SetActive(false);
        }

        if (indexNumber == 1)
        {
            animator.SetBool(flashlightEquippedID, false);
            animator.SetBool(pistolEquippedID, true);
            HUD.Instance.Reticle.SetActive(true);
        }
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
        if (Input.GetButtonDown("Fire") && fireCooldown <= 0 && bulletsInMagazine > 0 && reloading == false && animator.GetBool(pistolEquippedID) == true && Cursor.lockState == CursorLockMode.Locked)
        {
            FirePistol();
        }

        else
        {
            animator.SetBool(pistolFiredID, false);
        }

        //Reload Pistol
        if (Input.GetButtonDown("Reload") && animator.GetBool(pistolEquippedID) == true && reloading == false && bulletsInMagazine >= magazineSize == false && ammoClips > 0)
        {
            Instantiate(reloadPrefab, pistol.transform);
            ReloadPistol();
        }

        else
        {
            animator.SetBool(isReloadingID, false);
        }

        if (bulletsInMagazine == 8)
        {
            bulletOne.color = Color.white;
            bulletTwo.color = Color.white;
            bulletThree.color = Color.white;
            bulletFour.color = Color.white;
            bulletFive.color = Color.white;
            bulletSix.color = Color.white;
            bulletSeven.color = Color.white;
            bulletEight.color = Color.white;
        }

        if (bulletsInMagazine == 7)
        {
            bulletOne.color = Color.black;
            bulletTwo.color = Color.white;
            bulletThree.color = Color.white;
            bulletFour.color = Color.white;
            bulletFive.color = Color.white;
            bulletSix.color = Color.white;
            bulletSeven.color = Color.white;
            bulletEight.color = Color.white;
        }

        if (bulletsInMagazine == 6)
        {
            bulletOne.color = Color.black;
            bulletTwo.color = Color.black;
            bulletThree.color = Color.white;
            bulletFour.color = Color.white;
            bulletFive.color = Color.white;
            bulletSix.color = Color.white;
            bulletSeven.color = Color.white;
            bulletEight.color = Color.white;
        }

        if (bulletsInMagazine == 5)
        {
            bulletOne.color = Color.black;
            bulletTwo.color = Color.black;
            bulletThree.color = Color.black;
            bulletFour.color = Color.white;
            bulletFive.color = Color.white;
            bulletSix.color = Color.white;
            bulletSeven.color = Color.white;
            bulletEight.color = Color.white;
        }

        if (bulletsInMagazine == 4)
        {
            bulletOne.color = Color.black;
            bulletTwo.color = Color.black;
            bulletThree.color = Color.black;
            bulletFour.color = Color.black;
            bulletFive.color = Color.white;
            bulletSix.color = Color.white;
            bulletSeven.color = Color.white;
            bulletEight.color = Color.white;
        }

        if (bulletsInMagazine == 3)
        {
            bulletOne.color = Color.black;
            bulletTwo.color = Color.black;
            bulletThree.color = Color.black;
            bulletFour.color = Color.black;
            bulletFive.color = Color.black;
            bulletSix.color = Color.white;
            bulletSeven.color = Color.white;
            bulletEight.color = Color.white;
        }

        if (bulletsInMagazine == 2)
        {
            bulletOne.color = Color.black;
            bulletTwo.color = Color.black;
            bulletThree.color = Color.black;
            bulletFour.color = Color.black;
            bulletFive.color = Color.black;
            bulletSix.color = Color.black;
            bulletSeven.color = Color.white;
            bulletEight.color = Color.white;
        }

        if (bulletsInMagazine == 1)
        {
            bulletOne.color = Color.black;
            bulletTwo.color = Color.black;
            bulletThree.color = Color.black;
            bulletFour.color = Color.black;
            bulletFive.color = Color.black;
            bulletSix.color = Color.black;
            bulletSeven.color = Color.black;
            bulletEight.color = Color.white;
        }

        if (bulletsInMagazine == 0)
        {
            bulletOne.color = Color.black;
            bulletTwo.color = Color.black;
            bulletThree.color = Color.black;
            bulletFour.color = Color.black;
            bulletFive.color = Color.black;
            bulletSix.color = Color.black;
            bulletSeven.color = Color.black;
            bulletEight.color = Color.black;
        }

        if (playerRaycasting.whatIHit.collider != null)
        {
            if (playerRaycasting.whatIHit.collider.gameObject.tag == "Interactable")
            {
                animator.SetBool(nearInteractableID, true);

                if (playerRaycasting.whatIHit.collider.gameObject.name == "Pistol Ammo" && Input.GetButtonDown("Interact"))
                {
                    Destroy(playerRaycasting.whatIHit.collider.gameObject);
                    GetAmmoClip();
                }
            }
        }

        else
        {
            animator.SetBool(nearInteractableID, false);
        }

       /* //Walking
        if (characterController.velocity.magnitude > 0 && footstepControllerPrefab.activeInHierarchy == false)
        {
                footstepControllerPrefab.SetActive(true);
        }
        */
    }
    
    void FirePistol()
    {
        fireCooldown += 1.5f;
        animator.SetBool(pistolFiredID, true);
        Rigidbody instantiatedProjectile = Instantiate(projectile, playerCamera.transform.position + playerCamera.transform.forward, playerCamera.transform.rotation);
        instantiatedProjectile.velocity = playerCamera.transform.forward * projectileSpeed;
        bulletsInMagazine -= 1;
        Instantiate(gunshotPrefab, pistol.transform.position, pistol.transform.rotation, null);
        StartCoroutine("MuzzleFlash");
    }

    void ReloadPistol()
    {
        reloading = true;
        animator.SetBool(isReloadingID, true);
        StartCoroutine("ReloadWait");
    }

    void GetAmmoClip()
    {
        ammoClips += 1;
    }

    IEnumerator MuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        muzzleFlash.SetActive(false);
    }

    IEnumerator ReloadWait()
    {
        yield return new WaitForSeconds(1.6f);
        bulletsInMagazine = magazineSize;
        ammoClips -= 1;
        reloading = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation_Manager : MonoBehaviour
{
    public PlayerRaycasting playerRaycasting;
    public HUD hud;

    public Animator animator;
    public GameObject pistol;
    public GameObject muzzleFlash;
    public GameObject flashlight;
    public Rigidbody projectile;
    public Camera playerCamera;

    public float projectileSpeed;

    private int pistolFiredID;
    private int nearInteractableID;
    private int pistolEquippedID;
    private int flashlightEquippedID;
    private int isReloadingID;

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
    }

    void Update()
    {
        print(indexNumber);
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

        if (playerRaycasting.whatIHit.collider != null)
        {
            if (playerRaycasting.whatIHit.collider.gameObject.tag == "Interactable")
            {
                animator.SetBool(nearInteractableID, true);
            }
        }

        else
        {
            animator.SetBool(nearInteractableID, false);
        }

    }
    
    void FirePistol()
    {
        fireCooldown += 1.5f;
        animator.SetBool(pistolFiredID, true);
        Rigidbody instantiatedProjectile = Instantiate(projectile, playerCamera.transform.position + playerCamera.transform.forward * 3, playerCamera.transform.rotation);
        instantiatedProjectile.velocity = playerCamera.transform.forward * projectileSpeed;
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

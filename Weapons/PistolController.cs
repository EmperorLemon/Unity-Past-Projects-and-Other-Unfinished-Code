using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{
    Animator pistolAnimator;
    Pistol pistol;

    SwapWeapons swapWeapons;

    private void Start()
    {
        pistolAnimator = GetComponent<Animator>();
        pistol = GetComponent<Pistol>();

        swapWeapons = GetComponentInParent<SwapWeapons>();
    }

    private void Update()
    {
        if (pistol.isReloading == true)
        {
            pistolAnimator.SetBool("isReloading", true);
        }
        else
        {
            pistolAnimator.SetBool("isReloading", false);
        }

        if (pistol.noAmmo == true)
        {
            pistolAnimator.SetBool("noAmmo", true);
        }
        else
        {
            pistolAnimator.SetBool("noAmmo", false);
        }

        if (pistol.isAiming == true)
        {
            pistolAnimator.SetBool("isAiming", true);
        }
        else
        {
            pistolAnimator.SetBool("isAiming", false);
        }

        if (swapWeapons.hasEquippedPistol == true)
        {
            pistolAnimator.SetBool("pistolIsEquipped", true);
        }
        else
        {
            pistolAnimator.SetBool("pistolIsEquipped", false);
        }
    }
}

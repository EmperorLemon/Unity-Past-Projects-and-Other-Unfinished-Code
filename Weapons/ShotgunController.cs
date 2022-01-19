using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : MonoBehaviour
{
    Animator shotgunAnimator;
    Shotgun shotgun;

    SwapWeapons swapWeapons;

    private void Start()
    {
        shotgunAnimator = GetComponent<Animator>();
        shotgun = GetComponent<Shotgun>();

        swapWeapons = GetComponentInParent<SwapWeapons>();
    }

    private void Update()
    {
        if (shotgun.isReloading == true)
        {
            shotgunAnimator.SetBool("isReloading", true);
        }
        else
        {
            shotgunAnimator.SetBool("isReloading", false);
        }

        if (shotgun.noAmmo == true)
        {
            shotgunAnimator.SetBool("noAmmo", true);
        }
        else
        {
            shotgunAnimator.SetBool("noAmmo", false);
        }

        if (shotgun.isAiming == true)
        {
            shotgunAnimator.SetBool("isAiming", true);
        }
        else
        {
            shotgunAnimator.SetBool("isAiming", false);
        }

        if (shotgun.hasFired == true)
        {
            shotgunAnimator.SetBool("hasFired", true);
        }
        else
        {
            shotgunAnimator.SetBool("hasFired", false);
        }

        if (swapWeapons.hasEquippedShotgun == true)
        {
            shotgunAnimator.SetBool("shotgunIsEquipped", true);
        }
        else
        {
            shotgunAnimator.SetBool("shotgunIsEquipped", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public Transform shellSpawn;
    public Transform shellRelease;
    public Shell shell;

    public EmptyShell emptyShell;

    [HideInInspector]
    public bool isReloading = false;
    [HideInInspector]
    public bool noAmmo = false;
    [HideInInspector]
    public bool isAiming = false;
    [HideInInspector]
    public bool hasFired = false;

    float fireRate = 1f;
    float nextFire = 0.0f;

    public int Ammo = 20;

    AudioManager shotgunAudio;
    // ParticleSystem muzzleFlash;

    [HideInInspector]
    public int currentAmmo;

    private void Start()
    {
        currentAmmo = Ammo;
        shotgunAudio = FindObjectOfType<AudioManager>();
        // muzzleFlash = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0 && Time.time > nextFire && isReloading != true)
        {
            StartCoroutine("Shoot");
            shotgunAudio.Play("Shoot");

            nextFire = Time.time + fireRate;

            // muzzleFlash.Play();
        }
        else if (Input.GetMouseButtonDown(0) && currentAmmo == 0)
        {
            shotgunAudio.Play("No Ammo");
        }

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < Ammo)
        {
            StartCoroutine("Reload");
        }

        if (Input.GetMouseButton(1))
        {
            isAiming = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isAiming = false;
        }
    }

    IEnumerator Shoot()
    {
        Shell newShell = Instantiate(shell, shellSpawn.position, shellSpawn.rotation);

        hasFired = true;

        newShell.transform.Rotate(Vector3.right * 90);

        var rb = newShell.GetComponent<Rigidbody>();

        rb.AddForce(shellSpawn.forward * 2000);

        currentAmmo--;

        if (currentAmmo == 0)
        {
            print("Out of Slugs");

            noAmmo = true;
        }

        yield return new WaitForSeconds(0.5f);

        EmptyShell shellDrop = Instantiate(emptyShell, shellRelease.position, shellRelease.rotation);

        shellDrop.transform.Rotate(Vector3.right * 90);

        var shellPhysics = shellDrop.GetComponent<Rigidbody>();

        shellPhysics.AddForce(Vector3.up * 100);

        shellPhysics.AddForce(Vector3.right * 50);

        hasFired = false;
    }

    IEnumerator Reload()
    {
        isReloading = true;

        print("Reloading Shotgun");

        yield return new WaitForSeconds(3f);

        currentAmmo = Ammo;

        isReloading = false;

        noAmmo = false;

        print("Reloaded Slugs");
    }
}

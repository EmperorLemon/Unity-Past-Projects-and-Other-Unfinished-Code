using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Transform bulletSpawn;
    public Transform casingSpawn;
    public BulletCasing casing;
    public Bullet bullet;

    [HideInInspector]
    public bool isReloading = false;
    [HideInInspector]
    public bool noAmmo = false;
    [HideInInspector]
    public bool isAiming = false;

    public int Ammo = 20;

    AudioManager pistolAudio;
    ParticleSystem muzzleFlash;

    [HideInInspector]
    public int currentAmmo;

    private void Start()
    {
        currentAmmo = Ammo;
        pistolAudio = FindObjectOfType<AudioManager>();
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            StartCoroutine("Shoot");
            pistolAudio.Play("Gunshot");
            muzzleFlash.Play();
        }
        else if (Input.GetMouseButtonDown(0) && currentAmmo == 0)
        {
            pistolAudio.Play("No Ammo");
        }

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < Ammo)
        {
            StartCoroutine("Reload");
            pistolAudio.Play("Reload");
            pistolAudio.Play("Ejecting Magazine");
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
        Bullet newBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);

        newBullet.transform.Rotate(Vector3.right * 90);

        var rb = newBullet.GetComponent<Rigidbody>();

        rb.AddForce(bulletSpawn.forward * 2000);

        currentAmmo--;

        if (currentAmmo == 0)
        {
            print("Out of Ammo");

            noAmmo = true;
        }

        BulletCasing newCasing = Instantiate(casing, casingSpawn.position, casingSpawn.rotation);

        // newCasing.transform.Rotate(Vector3.right * 90);

        var casingPhysics = newCasing.GetComponent<Rigidbody>();

        casingPhysics.AddForce(Vector3.up * 100);

        casingPhysics.AddForce(Vector3.left * 50);

        yield return new WaitForSeconds(2f);
    }

    IEnumerator Reload()
    {
        isReloading = true;

        print("Reloading Pistol");

        yield return new WaitForSeconds(1.5f);

        currentAmmo = Ammo;

        isReloading = false;

        noAmmo = false;

        print("Reloaded Ammo");
    }


}

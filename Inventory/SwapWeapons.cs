using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWeapons : MonoBehaviour
{
    public int currentWeapon;
    public Transform[] weapons;

    [HideInInspector]
    public bool hasEquippedPistol = false;
    [HideInInspector]
    public bool hasEquippedShotgun = false;

    ItemPickup itemPickup;

    private void Start()
    {
        itemPickup = GetComponent<ItemPickup>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && itemPickup.hasPickedUpPistol == true)
        {
            SwitchWeapons(0);
            hasEquippedPistol = true;
            hasEquippedShotgun = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && itemPickup.hasPickedUpShotgun == true)
        {
            SwitchWeapons(1);
            hasEquippedShotgun = true;
            hasEquippedPistol = false;
        }
    }

    void SwitchWeapons(int x)
    {
        currentWeapon = x;

        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == x)
            {
                weapons[i].gameObject.SetActive(true);
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }
}

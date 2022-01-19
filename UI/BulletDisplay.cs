using UnityEngine.UI;
using UnityEngine;

public class BulletDisplay : MonoBehaviour
{
    public Text totalAmmo;
    public Text currentAmmo;

    public Image bulletReloadDisplay;

    SwapWeapons swapWeapons;

    public Pistol pistol;

    private void Start()
    {
        swapWeapons = FindObjectOfType<SwapWeapons>();
    }

    private void Update()
    {
        if (swapWeapons.hasEquippedPistol == true)
        {
            totalAmmo.gameObject.SetActive(true);
            currentAmmo.gameObject.SetActive(true);
            bulletReloadDisplay.gameObject.SetActive(true);

            totalAmmo.text = pistol.Ammo.ToString();
            currentAmmo.text = pistol.currentAmmo.ToString() + "/";

            if (pistol.currentAmmo < 10)
            {
                currentAmmo.text = pistol.currentAmmo.ToString() + " /";
            }

            if (pistol.isReloading == true)
            {
                bulletReloadDisplay.fillAmount -= 1.0f / 1.5f * Time.deltaTime;
            }
            else
            {
                bulletReloadDisplay.fillAmount = 1;
            }
        }
        else
        {
            totalAmmo.gameObject.SetActive(false);
            currentAmmo.gameObject.SetActive(false);
            bulletReloadDisplay.gameObject.SetActive(false);
        }
    }
}

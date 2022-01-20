using UnityEngine.UI;
using UnityEngine;

public class ShellDisplay : MonoBehaviour
{
    public Text totalSlugs;
    public Text currentSlugs;

    public Image slugReloadDisplay;

    SwapWeapons swapWeapons;

    public Shotgun shotgun;

    private void Start()
    {
        swapWeapons = FindObjectOfType<SwapWeapons>();
    }

    private void Update()
    {
        if (swapWeapons.hasEquippedShotgun == true)
        {
            totalSlugs.gameObject.SetActive(true);
            currentSlugs.gameObject.SetActive(true);
            slugReloadDisplay.gameObject.SetActive(true);

            totalSlugs.text = shotgun.Ammo.ToString();

            currentSlugs.text = shotgun.currentAmmo.ToString() + " /";

            if (shotgun.isReloading == true)
            {
                slugReloadDisplay.fillAmount -= 1.0f / 2.5f * Time.deltaTime;
            }
            else
            {
                slugReloadDisplay.fillAmount = 1;
            }
        }
        else
        {
            totalSlugs.gameObject.SetActive(false);
            currentSlugs.gameObject.SetActive(false);
            slugReloadDisplay.gameObject.SetActive(false);
        }
    }
}

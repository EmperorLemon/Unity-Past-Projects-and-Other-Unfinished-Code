using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    private Text ammoText;

    private GunScript gunScript;

    private void Start()
    {
        gunScript = FindObjectOfType<GunScript>();
        ammoText = GetComponent<Text>();
    }

    private void Update()
    {
        ammoText.text = "Ammo Remaining " + gunScript.ammo;
    }
}

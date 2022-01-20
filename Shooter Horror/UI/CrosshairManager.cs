using UnityEngine.UI;
using UnityEngine;

public class CrosshairManager : MonoBehaviour
{
    public Image crosshair;

    public Animator pistolAnimator;

    private void Update()
    {
        if (pistolAnimator.GetBool("isAiming") == true)
        {
            crosshair.gameObject.SetActive(false);
        }
        else
        {
            crosshair.gameObject.SetActive(true);
        }
    }
}

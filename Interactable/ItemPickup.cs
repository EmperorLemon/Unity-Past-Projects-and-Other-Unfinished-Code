using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ItemPickup : MonoBehaviour
{
    [Range(1,10)]
    public float pickupDistance;
    public LayerMask pickupLayer;

    [HideInInspector]
    public bool hasPickedUpPistol = false;
    [HideInInspector]
    public bool hasPickedUpShotgun = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, pickupDistance, pickupLayer))
            {
                if (hit.collider.name == "Shotgun Pickup")
                {
                    Debug.Log("Picked Up Shotgun");
                    Destroy(hit.collider.gameObject);
                    hasPickedUpShotgun = true;
                }

                if (hit.collider.name == "Pistol Pickup")
                {
                    Debug.Log("Picked Up Pistol");
                    Destroy(hit.collider.gameObject);
                    hasPickedUpPistol = true;
                }
            }
        }
    }
}

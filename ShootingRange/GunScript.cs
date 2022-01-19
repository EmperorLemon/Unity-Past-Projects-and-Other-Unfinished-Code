using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public ShootingManager manager;

    public Transform gunHold;
    public Transform gunEnd;

    public GameObject ammoCounter;
    public GameObject targetCounter;

    [HideInInspector]
    public bool gunEquipped;

    [HideInInspector]
    public int ammo;
    [HideInInspector]
    public float totalScore;
    [Range(10,25)]
    public int maxAmmo;

    private Camera cam;

    private LineRenderer laserLine;

    // Target Settings
    private Vector3 rotationVector;
    [HideInInspector]
    public int targetsHit;
    [HideInInspector]
    public int targetsMissed;
    private int totalTargets;
    private Target[] targets;

    private float gunRange = 20f;
    private float shootDistance;
    private float score;


    private void Start()
    {
        ammoCounter.SetActive(false);
        targetCounter.SetActive(false);

        cam = GetComponentInChildren<Camera>();
        laserLine = GetComponent<LineRenderer>();
        targets = FindObjectsOfType<Target>();

        totalTargets = targets.Length;
        // print("There are " + totalTargets + " Targets Currently in this scene.");

        ammo = maxAmmo;
    }

    private void Update()
    {
        laserLine.enabled = false;
        laserLine.SetPosition(0, gunEnd.position);

        if (!manager.gameStarted)
        {
            ammoCounter.SetActive(false);
            targetCounter.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GrabGun();
            PressButton();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (gunEquipped && ammo > 0)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    void PressButton()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 1f))
        {
            if (hit.collider.CompareTag("Start Button"))
            {
                manager.StartGame();
            }
        }
    }

    void GrabGun()
    {
        if (!gunEquipped && manager.gameStarted)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 1f))
            {
                if (hit.collider.CompareTag("Gun"))
                {
                    ammoCounter.SetActive(true);

                    targetCounter.SetActive(true);

                    hit.collider.transform.SetParent(gunHold);

                    hit.collider.transform.position = gunHold.position;

                    hit.collider.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

                    gunEquipped = true;
                }
            }
        }
    }

    private IEnumerator Shoot()
    {
        Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        if (Physics.Raycast(rayOrigin, cam.transform.forward, out RaycastHit hit, gunRange) && ammo > 0) 
        {
            ammo--;

            laserLine.enabled = true;
            laserLine.SetPosition(1, hit.point);

            if (hit.collider.CompareTag("Target"))
            {
                targetsHit++;

                shootDistance = Vector3.Distance(hit.collider.transform.position, gunEnd.position);
                score = shootDistance * 10 / 2;
                totalScore += score;
                rotationVector = hit.transform.rotation.eulerAngles;
                rotationVector.x = 25;
                hit.transform.rotation = Quaternion.Euler(rotationVector);

                yield return new WaitForSeconds(3f);

                rotationVector.x = 90;
                hit.transform.rotation = Quaternion.Euler(rotationVector);
            }
            else
                targetsMissed++;
        }
    }
}

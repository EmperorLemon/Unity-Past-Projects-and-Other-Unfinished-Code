using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ClawMovement : MonoBehaviour
{
    [Header("References")]
    public Camera cam;
    public Transform parentTransform;
    public Transform ropeParent;

    [Header("Values")]
    public float movementSpeed = 5f;
    public float scalarSpeed = 5f;

    private Rigidbody rb;

    private float x, y, z;
    private float minX, maxX;
    private float minY, maxY;
    private float minZ, maxZ;

    private int buttonState = 0;

    private bool moveUpY;
    private bool moveDownY;
    private bool isMovingX;
    private bool isMovingZ;

    private Vector3 movementX = Vector3.zero;
    private Vector3 movementZ = Vector3.zero;

    private Vector3 pos;
    private Vector3 offset;
    private Vector3 scale;

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();

        offset = rb.position;

        minX = 0f;
        maxX = 0.9f;
        minY = 2f;
        maxY = 4f;
        minZ = 0f;
        maxZ = 0.92f;
    }

    private void Update()
    {
        x = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        z = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            isMovingX = true;
        else
            isMovingX = false;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            isMovingZ = true;
        else
            isMovingZ = false;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (buttonState == 0)
            {
                moveDownY = true;
                moveUpY = false;
                buttonState++;
            }
            else
            {
                moveUpY = true;
                moveDownY = false;
                buttonState = 0;
            }
        }

        if (moveDownY && scale.y <= maxY)
            DropClaw();

        if (moveUpY && scale.y >= minY)
            PullClaw();

        movementX = cam.transform.right * x;
        movementZ = cam.transform.forward * z;
    }
    private void FixedUpdate()
    {
        if (isMovingX)
            MoveX();

        if (isMovingZ)
            MoveZ();
    }

    private void LateUpdate()
    {
        pos = rb.position;

        pos.x = Mathf.Clamp(pos.x, minX + parentTransform.position.x, maxX + parentTransform.position.x);
        pos.z = Mathf.Clamp(pos.z, minZ + parentTransform.position.z, maxZ + parentTransform.position.z);

        rb.position = new Vector3(pos.x, pos.y, pos.z);
    }

    private void DropClaw() // Claw Goes Down
    {
        scale = ropeParent.localScale;

        scale.y += scalarSpeed * Time.deltaTime;

        ropeParent.localScale = scale;

        if (scale.y <= minY)
            moveDownY = false;
    }

    private void PullClaw() // Claw Goes Up
    {
        scale = ropeParent.localScale;

        scale.y -= scalarSpeed * Time.deltaTime;

        ropeParent.localScale = scale;

        if (scale.y >= maxY)
            moveDownY = false;
    }

    private void MoveX()
    {
        rb.MovePosition(rb.position + movementX * Time.deltaTime * movementSpeed);
    }

    private void MoveZ()
    {
        rb.MovePosition(rb.position + movementZ * Time.deltaTime * movementSpeed);
    }
}

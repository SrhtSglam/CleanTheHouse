using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public Transform playerBody;

    float xRot, yRot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
        yRot += mouseX;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);  

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        playerBody.rotation = Quaternion.Euler(0, yRot, 0);
        
    }
}

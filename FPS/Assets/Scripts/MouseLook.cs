//Chris Riordan
//6-14-2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controls main camera with mouse
public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 800f;

    public Transform playerBody;

    float xRotation = 0f;

    //Locks cursor to center of view on start
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Updates mouse movement and camera rotation
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

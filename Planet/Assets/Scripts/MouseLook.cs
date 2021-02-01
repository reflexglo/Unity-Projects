//Chris Riordan
//2-1-2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controls main camera with mouse
public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 800f;
    public Transform playerBody;
    float xRotation = 0f;
    float yRotation = 0f;
    bool endGame = false;
    //Locks cursor to center of view
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    //updates mouse movement and camera rotation
    void Update()
    {
        if (!endGame) {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
    //Checks if game has ended to restrict movement
    public void setEnd(bool end)
    {
        endGame = end;
    }
}

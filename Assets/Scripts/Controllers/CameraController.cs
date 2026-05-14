using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 700f;
    [SerializeField] private Transform playerBody;
    float xRotation = 0f;
    void Update()
    {
        //horizontal camera logic
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        if (mouseX > 0 || mouseX < 0)
        {
            playerBody.Rotate(Vector3.up * mouseX);
        }
        else
        {
            playerBody.Rotate(Vector3.up * 0);
        }
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
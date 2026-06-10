using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Generated.PropertyProviders;
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
        if (Input.GetKeyDown("1") && mouseSensitivity >= 50f)
        {
            mouseSensitivity -= 25f;
            UIController.Instance.UpdateTextBox("Sensitivity: " + mouseSensitivity);

            StartCoroutine(ClearSenseText());
        }
        else if (Input.GetKeyDown("2") && mouseSensitivity <= 900f)
        {
            mouseSensitivity += 25f;
            UIController.Instance.UpdateTextBox("Sensitivity: " + mouseSensitivity);

            StartCoroutine(ClearSenseText());
        }
    }
    
    IEnumerator ClearSenseText()
    {
        yield return new WaitForSeconds(1f);

        UIController.Instance.UpdateTextBox("");
    }
}
//hellloooo
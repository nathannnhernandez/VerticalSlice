using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Crosshair : MonoBehaviour
{    
    [SerializeField] private TextMeshProUGUI crosshairPrefab;
    private TextMeshProUGUI crosshairInstance;
    public void InstantiateCrossHair()
    {
        Canvas canvas = FindObjectOfType<Canvas>();

        crosshairInstance = Instantiate(crosshairPrefab, canvas.transform);
        crosshairInstance.rectTransform.anchoredPosition = Vector2.zero;

        crosshairPrefab.text = "*";
    }
    public void DestroyCrosshair()
    {
        if (crosshairInstance != null)
        {
            Destroy(crosshairInstance.gameObject);
            crosshairInstance = null;
        }
    }   
    public void ShowCrosshair()
    {
        crosshairPrefab.text = "*";
        Debug.Log("show");
    }
    public void HideCrosshair()
    {
        crosshairPrefab.text = " ";
        Debug.Log("hide");
    }
}

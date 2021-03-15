using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera myCamera;
    [SerializeField] float defualtFOV = 60;
    [SerializeField] float zoomFOV = 20;

    [SerializeField] RigidbodyFirstPersonController myFPSController;
    [SerializeField] float defualtSensitivity = 2f;
    [SerializeField] float zoomSensitivity = 1f;

    [SerializeField] bool isZoomIn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isZoomIn = true;
        }

        if (Input.GetButtonUp("Fire2"))
        {
            isZoomIn = false;
        }
        ToggleZoom(isZoomIn);
        ToggleMouseSensitivie(isZoomIn);
    }

    void ToggleZoom(bool zoom)
    {
        if (zoom)
        {
            myCamera.fieldOfView = zoomFOV;
        }
        else
        {
            myCamera.fieldOfView = defualtFOV;
        }
    }

    void ToggleMouseSensitivie(bool zoom)
    {
        if (zoom)
        {
            myFPSController.mouseLook.XSensitivity = zoomSensitivity;
            myFPSController.mouseLook.YSensitivity = zoomSensitivity;
        }
        else
        {
            myFPSController.mouseLook.XSensitivity = defualtSensitivity;
            myFPSController.mouseLook.YSensitivity = defualtSensitivity;
        }
    }
}

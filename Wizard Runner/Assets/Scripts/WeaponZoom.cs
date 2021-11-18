using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] RigidbodyFirstPersonController rigidbodyFPC;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedMouseSensitivity = .5f;
    [SerializeField] float defaultMouseSensitivity = 2f;

    bool ZoomedInToggle = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))

            if (!ZoomedInToggle)
            {
                ZoomedInToggle = true;
                FPCamera.fieldOfView = zoomedInFOV;
                rigidbodyFPC.mouseLook.XSensitivity = zoomedMouseSensitivity;
                rigidbodyFPC.mouseLook.YSensitivity = zoomedMouseSensitivity;
            }
            else
            {
                ZoomedInToggle = false;
                FPCamera.fieldOfView = zoomedOutFOV;
                rigidbodyFPC.mouseLook.XSensitivity = defaultMouseSensitivity;
                rigidbodyFPC.mouseLook.YSensitivity = defaultMouseSensitivity;
            }
    }
}

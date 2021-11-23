using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffLightPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 70f;
    [SerializeField] float addedIntensity = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var flashlightSystem = other.GetComponentInChildren<FlashlightSystem>();

            flashlightSystem.RestoreLightAngle(restoreAngle);
            flashlightSystem.AddLightIntensity(addedIntensity);
            Destroy(gameObject);
        }
    }
}

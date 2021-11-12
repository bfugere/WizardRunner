using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 25f;
    [SerializeField] ParticleSystem staffVFX;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        PlayStaffVFX();
        ProcessRaycast();
    }

    void PlayStaffVFX()
    {
        staffVFX.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);
            // TODO: Add hit effects.
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
                return;
            target.TakeDamage(damage);
        }
        else
            return;
    }
}

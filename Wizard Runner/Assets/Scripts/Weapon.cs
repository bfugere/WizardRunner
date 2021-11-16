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
    [SerializeField] GameObject hitVFX;
    [SerializeField] Mana manaSlot;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    void Shoot()
    {
        if (manaSlot.GetCurrentAmmo() > 0)
        {
            PlayStaffVFX();
            ProcessRaycast();
            manaSlot.ReduceCurrentAmmo();
        }
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
            CreateHitVFX(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
                return;
            target.TakeDamage(damage);
        }
        else
            return;
    }

    void CreateHitVFX(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .5f);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 25f;
    [SerializeField] ParticleSystem staffVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Mana manaSlot;
    [SerializeField] ManaType manaType;
    [SerializeField] TextMeshProUGUI manaText;

    void Update()
    {
        DisplayMana();
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    void DisplayMana()
    {
        int currentMana = manaSlot.GetCurrentMana(manaType);
        manaText.text = currentMana.ToString();
    }

    void Shoot()
    {
        if (manaSlot.GetCurrentMana(manaType) > 0)
        {
            PlayStaffVFX();
            ProcessRaycast();
            manaSlot.ReduceCurrentMana(manaType);
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

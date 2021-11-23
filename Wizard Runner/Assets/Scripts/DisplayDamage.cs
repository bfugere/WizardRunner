using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas damageTakenCanvas;
    [SerializeField] float damageTakenDisplayTime = 1f;
    
    void Start()
    {
        DisableCanvas();
    }

    public void ShowDamageTakenCanvas()
    {
        StartCoroutine(ShowDamageImage());
    }

    IEnumerator ShowDamageImage()
    {
        EnableCanvas();
        yield return new WaitForSeconds(damageTakenDisplayTime);
        DisableCanvas();
    }

    void EnableCanvas()
    {
        damageTakenCanvas.enabled = true;
    }

    void DisableCanvas()
    {
        damageTakenCanvas.enabled = false;
    }
}

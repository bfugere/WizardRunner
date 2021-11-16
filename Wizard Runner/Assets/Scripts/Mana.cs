using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] int currentMana = 10;

    public int GetCurrentAmmo()
    {
        return currentMana;
    }

    public void ReduceCurrentAmmo()
    {
        currentMana--;
    }
}

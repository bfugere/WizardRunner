using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPickup : MonoBehaviour
{
    [SerializeField] int manaAmount = 5;
    [SerializeField] ManaType manaType;

    Mana mana;

    void Start()
    {
        mana = FindObjectOfType<Mana>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            mana.IncreaseCurrentMana(manaType, manaAmount);
            Destroy(gameObject);
        }
    }
}

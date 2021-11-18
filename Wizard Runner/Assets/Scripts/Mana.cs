using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] ManaPouch[] manaPouch;
    
    [System.Serializable]
    private class ManaPouch
    {
        public ManaType manaType;
        public int currentMana;
    }

    public int GetCurrentMana(ManaType manaType)
    {
        return GetManaType(manaType).currentMana;
    }

    public void ReduceCurrentMana(ManaType manaType)
    {
        GetManaType(manaType).currentMana--;
    }

    private ManaPouch GetManaType(ManaType manaType)
    {
        foreach (ManaPouch type in manaPouch)
        {
            if (type.manaType == manaType)
                return type;
        }
        return null;
    }
}

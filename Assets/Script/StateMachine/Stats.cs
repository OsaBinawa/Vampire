using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStats", menuName = "Character/Stats")]
public class Stats : ScriptableObject
{
    public float baseHealth;
    public float baseStrength;

    public List<Equipment> equippedItems;

    public float health
    {
        get
        {
            float totalHealth = baseHealth;
            foreach (var item in equippedItems)
            {
                totalHealth += item.healthBonus;
            }
            return totalHealth;
        }
    }

    public float strength
    {
        get
        {
            float totalStrength = baseStrength;
            foreach (var item in equippedItems)
            {
                totalStrength += item.strengthBonus;
            }
            return totalStrength;
        }
    }
}

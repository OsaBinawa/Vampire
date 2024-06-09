using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEquipment", menuName = "Character/Equipment")]
public class Equipment : ScriptableObject
{
    public string itemName;
    public float healthBonus;
    public float strengthBonus;
}

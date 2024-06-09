using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Stats characterStats;
    //public EquipmentSlot[] equipmentSlots;
    public float HP;
    public float Dmg;

    void Start()
    {
        if (characterStats != null)
        {
            //characterStats.ResetStats();
            Debug.Log("Initial Health: " + (characterStats.health + HP));
            Debug.Log("Initial Strength: " + (characterStats.strength + Dmg));

        }
    }

    /*public void EquipItem(int slotIndex, Equipment newEquipment)
    {
        if (slotIndex >= 0 && slotIndex < equipmentSlots.Length)
        {
            EquipmentSlot slot = equipmentSlots[slotIndex];
            if (slot.currentEquipment != null)
            {
                characterStats.RemoveEquipment(slot.currentEquipment);
            }

            slot.Equip(newEquipment);
            characterStats.ApplyEquipment(newEquipment);

            Debug.Log("Equipped " + newEquipment.itemName);
            Debug.Log("New Health: " + characterStats.health);
            Debug.Log("New Strength: " + characterStats.strength);
        }
    }*/
}

using UnityEngine;

public class EquipmentSlot : MonoBehaviour
{
    public Equipment currentEquipment;

    public void Equip(Equipment newEquipment)
    {
        currentEquipment = newEquipment;
    }
}

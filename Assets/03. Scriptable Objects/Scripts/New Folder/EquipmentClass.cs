using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Equipment Class", menuName = "Item/Equipment")]
public class EquipmentClass : ItemClass
{


    [Header("Weapon")]
    public int Damage;
    public int Defense;


    public override ItemClass GetItem() { return this; }
    public override EquipmentClass GetEquipment() { return this; }
    public override ConsumableClass GetConsumable() { return null; }
    public override KeyClass GetKey() { return null; }
}

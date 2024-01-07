using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Consumable Class", menuName = "Item/Consumable")]
public class ConsumableClass : ItemClass
{
    [Header("Consumable")]
    public float HealthAdded;
    public float ManaAdded;

    public override ItemClass GetItem() { return this; }
    public override EquipmentClass GetEquipment() { return null; }
    public override ConsumableClass GetConsumable() { return this; }
    public override KeyClass GetKey() { return null; }
}

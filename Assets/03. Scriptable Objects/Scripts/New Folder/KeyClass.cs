using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Key Class", menuName = "Item/Key")]
public class KeyClass : ItemClass
{
    public override ItemClass GetItem() { return this; }
    public override EquipmentClass GetEquipment() { return null; }
    public override ConsumableClass GetConsumable() { return null; }
    public override KeyClass GetKey() {return this;}
}
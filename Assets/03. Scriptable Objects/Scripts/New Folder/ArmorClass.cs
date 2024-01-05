using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Armor Class", menuName = "Item/Armor")]
public class ArmorClass : ItemClass
{
    [Header("Armor")]
    public float defense;
    public override ItemClass GetItem() { return this; }
    public override WeaponClass GetWeapon() { return null; }
    public override ArmorClass GetArmor() { return this; }
    public override ConsumableClass GetConsumable() { return null; }
}

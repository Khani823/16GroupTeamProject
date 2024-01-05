using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon Class", menuName = "Item/Weapon")]
public class WeaponClass : ItemClass
{
    public enum Weapontype
    {
        sword,
        hammer,
        gun,
        bow
    }

    [Header("Weapon")]
    public float Damage;
    public Weapontype weapontype;

    public override ItemClass GetItem() {return this;}
    public override WeaponClass GetWeapon() { return this; }
    public override ArmorClass GetArmor() { return null ; }
    public override ConsumableClass GetConsumable() { return null; }
}

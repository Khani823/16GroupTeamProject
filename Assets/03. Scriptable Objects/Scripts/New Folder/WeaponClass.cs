using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon Class", menuName = "Item/Weapon")]
public class WeaponClass : ItemClass
{


    [Header("Weapon")]
    public float Damage;
  

    public override ItemClass GetItem() {return this;}
    public override WeaponClass GetWeapon() { return this; }
    public override ArmorClass GetArmor() { return null ; }
    public override ConsumableClass GetConsumable() { return null; }
    public override KeyClass GetKey() { return null; }
}

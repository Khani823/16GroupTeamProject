using System.Collections;
using UnityEngine;

public abstract class ItemClass : ScriptableObject
{
    [Header("Item")]
    public string itemName;
    public Sprite itemIcon;
    public float price;
    public bool isStackable = true;

    public abstract ItemClass GetItem();
    public abstract WeaponClass GetWeapon();
    public abstract ArmorClass GetArmor();
    public abstract ConsumableClass GetConsumable();
}

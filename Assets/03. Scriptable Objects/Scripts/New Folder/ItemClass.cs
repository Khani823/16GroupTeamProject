using System.Collections;
using UnityEngine;


public enum Type 
{
    sword,
    hammer,
    gun,
    bow,
    helmet,
    armor,
    potion,
    key
}
public abstract class ItemClass : ScriptableObject
{
    [Header("Item")]
    public string itemName;
    public Sprite itemIcon;
    public float price;
    public bool isStackable = true;
    [Multiline] public string tooltip;
    public Type type;
    public bool isEquiped;

    public abstract ItemClass GetItem();
    public abstract WeaponClass GetWeapon();
    public abstract ArmorClass GetArmor();
    public abstract ConsumableClass GetConsumable();
    public abstract KeyClass GetKey();

    public void Equip()
    {
        EquipmentManager.Instance.Equip(this);
        
    }

}

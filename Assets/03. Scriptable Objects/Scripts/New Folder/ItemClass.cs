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
    public string tooltip;
    public Type type;
    public bool IsEquipped;


    public abstract ItemClass GetItem();
    public abstract EquipmentClass GetEquipment();
    public abstract ConsumableClass GetConsumable();
    public abstract KeyClass GetKey();



}

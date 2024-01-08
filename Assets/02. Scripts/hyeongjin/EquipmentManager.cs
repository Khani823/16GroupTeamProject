using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Progress;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager Instance;
    public ItemSlot itemslot;
    public InventoryUI inventoryUI;
    //public StatHandler statHandler;


    public void Awake()
    {
        Instance = this;
    }

    public ItemClass[] currentEquipment;

    public delegate void OnEquipmentChanged(ItemClass newitem, ItemClass olditem);
    public OnEquipmentChanged onEquipmentChanged;
    // Start is called before the first frame update
    void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(Type)).Length;
        currentEquipment = new ItemClass[numSlots];
    }

    public void Equip(ItemClass newitem)
    {
        int slotIndex = (int)newitem.type;

        ItemClass olditem = null;
        if (currentEquipment[slotIndex] == null)
        {
            currentEquipment[slotIndex] = newitem;
            currentEquipment[slotIndex].IsEquipped = true;
            //Debug.Log(currentEquipment[slotIndex].isEquiped);
        }
        else
        {
            UnEquip(currentEquipment[slotIndex]);
            currentEquipment[slotIndex] = newitem;
            currentEquipment[slotIndex].IsEquipped = true;
        }
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newitem, olditem);
        }


    }

    public void UnEquip(ItemClass olditem) 
    {
        int slotIndex = (int)olditem.type;
        if (currentEquipment[slotIndex] == olditem)
        {
            currentEquipment[slotIndex].IsEquipped = false; 
            currentEquipment[slotIndex] = null;
        }
        if (onEquipmentChanged != null)
        {   
            onEquipmentChanged.Invoke(null, olditem);
            
        }
    }
}

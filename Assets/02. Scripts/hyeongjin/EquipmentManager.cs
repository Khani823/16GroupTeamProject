using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using static UnityEditor.Progress;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager Instance;
    public ItemSlot itemslot;

    public void Awake()
    {
        Instance = this;
    }

    public ItemClass[] currentEquipment;
    // Start is called before the first frame update
    void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(Type)).Length;
        currentEquipment = new ItemClass[numSlots];
    }

    public void Equip(ItemClass newitem)
    {
        int slotIndex = (int)newitem.type;
        if (currentEquipment[slotIndex] == null)
        {
            currentEquipment[slotIndex] = newitem;
            currentEquipment[slotIndex].isEquiped = true;
            //Debug.Log(currentEquipment[slotIndex].isEquiped);
        }
        else
        {
            UnEquip(currentEquipment[slotIndex]);
            currentEquipment[slotIndex] = newitem;
            currentEquipment[slotIndex].isEquiped = true;
        }


    }

    public void UnEquip(ItemClass olditem) 
    {
        int slotIndex = (int)olditem.type;
        if (currentEquipment[slotIndex] == olditem)
        {
            currentEquipment[slotIndex].isEquiped = false; 
            currentEquipment[slotIndex] = null;
        }   
    }
}

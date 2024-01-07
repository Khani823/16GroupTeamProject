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

    public void Awake()
    {
        Instance = this;
    }

    public EquipmentClass[] currentEquipment;

    public delegate void OnEquipmentChanged(EquipmentClass newitem, EquipmentClass olditem);
    public OnEquipmentChanged onEquipmentChanged;
    // Start is called before the first frame update
    void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(Type)).Length;
        currentEquipment = new EquipmentClass[numSlots];
    }

    public void Equip(EquipmentClass newitem)
    {
        int slotIndex = (int)newitem.type;

        EquipmentClass olditem = null;
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
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newitem, olditem);
        }

    }

    public void UnEquip(EquipmentClass olditem) 
    {
        int slotIndex = (int)olditem.type;
        if (currentEquipment[slotIndex] == olditem)
        {
            currentEquipment[slotIndex].isEquiped = false; 
            currentEquipment[slotIndex] = null;
        }
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(null, olditem);
        }
    }
}

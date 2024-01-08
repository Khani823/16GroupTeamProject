using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PopupEquip : MonoBehaviour
{
    public ItemSlot slot;
    public TMP_Text infoText;
    public Button confirmBtn;
    public ItemClass item;
    public EquipmentManager equipmentManager;
    public InventoryManager inventoryManager;



    public void PopupSetting(ItemSlot slot)
    {
        if (slot.item.type == Type.key)
        {
            return;
        }

        else if (slot.item.IsEquipped)
        {
            infoText.text = "������ �����Ͻðڽ��ϱ�?";
            confirmBtn.onClick.RemoveAllListeners();
            confirmBtn.onClick.AddListener(() =>
            {
                
                equipmentManager.UnEquip(inventoryManager.items[slot.index].GetItem().GetEquipment());
                
                slot.ChangeEquip();
            });

        }
        else
        {
            infoText.text = "�����Ͻðڽ��ϱ�?";
            confirmBtn.onClick.RemoveAllListeners();
            confirmBtn.onClick.AddListener(() =>
            {
                
                equipmentManager.Equip(inventoryManager.items[slot.index].GetItem().GetEquipment());
                slot.ChangeEquip();
            });
        }
    }
}

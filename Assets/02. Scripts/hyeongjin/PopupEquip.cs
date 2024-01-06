using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

        if (slot.item.isEquiped)
        {
            infoText.text = "장착을 해제하시겠습니까?";
            confirmBtn.onClick.RemoveAllListeners();
            confirmBtn.onClick.AddListener(() =>
            {
                slot.Equipped();
                equipmentManager.UnEquip(inventoryManager.items[slot.index].GetItem());
                slot.ChangeEquip();
            });

        }
        else
        {
            infoText.text = "장착하시겠습니까?";
            confirmBtn.onClick.RemoveAllListeners();
            confirmBtn.onClick.AddListener(() =>
            {
                slot.Equipped();
                slot.ChangeEquip();
                equipmentManager.Equip(inventoryManager.items[slot.index].GetItem());
            });
        }
    }
}

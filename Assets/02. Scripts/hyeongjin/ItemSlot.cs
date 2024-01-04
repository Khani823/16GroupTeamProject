using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [HideInInspector]public ItemData inputData;
    [HideInInspector]public SlotClass slotClass;    
    public InventoryManager inventoryManager;
    public Image itemImage;
    public GameObject EquipMark;
    private ItemClass item;
    private GameObject[] slots;
    public ItemSlot itemslot;
    public GameObject popup;
    public PopupEquip popupEquip;
    public int index;

    // Start is called before the first frame update
    //public void Init(ItemData data)
    //{
    //    inputData = data;
    //    itemImage.sprite = data._iconSprite;
    //    itemImage.enabled = true;

    //    ChangeEquip();
    //}
    public void ChangeEquip()
    {
        if (inputData.isEquiped)
        {
            EquipMark.SetActive(true);
            Debug.Log("ÄÑÁü");
        }
        else
        {
            EquipMark.SetActive(false);
            Debug.Log("²¨Áü");
        }
    }
    public void Popup()
    {
        EquipPopup(inventoryManager.items[index].GetItem());
    }

    public void EquipPopup(ItemClass item)
    {
        SlotClass slot = inventoryManager.Contains(item);
        if (slot != null && slot.GetItem().isStackable == false)
        {
            Debug.Log("success");
            popup.SetActive(true);
            popupEquip.PopupSetting(this);
        }
        else if (slot != null && slot.GetItem().isStackable)
        {
            Debug.Log("¹°¾à");
        }
        else
        {
            Debug.Log("Failed");
        }
    }
}

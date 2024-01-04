using System.Collections;
using System.Collections.Generic;
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
        inventoryManager.EquipPopup(inventoryManager.items[1].GetItem());
    }
}

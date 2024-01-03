using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [HideInInspector]public ItemData inputData;
    public PopupEquip popupEquip;
    public Image itemImage;
    public GameObject EquipMark;
    // Start is called before the first frame update
    public void Init(ItemData data)
    {
        inputData = data;
        itemImage.sprite = data.image;
        itemImage.enabled = true;

        ChangeEquip();
    }
    public void ChangeEquip()
    {
        if (inputData.isEquiped)
        {
            EquipMark.SetActive(true);
        }
        else
        {
            EquipMark.SetActive(false);
        }
    }
    public void Popup()
    {
        popupEquip.PopupSetting(this);
    }
}

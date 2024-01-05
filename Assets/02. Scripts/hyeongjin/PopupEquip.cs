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
    private ItemClass item;

    public void PopupSetting(ItemSlot slot)
    {

        if (slot.inputData.isEquiped)
        {
            infoText.text = "장착을 해제하시겠습니까?";
            confirmBtn.onClick.RemoveAllListeners();
            confirmBtn.onClick.AddListener(() =>
            {
                slot.inputData.isEquiped = false;
                slot.ChangeEquip();
            });

        }
        else
        {
            infoText.text = "장착하시겠습니까?";
            confirmBtn.onClick.RemoveAllListeners();
            confirmBtn.onClick.AddListener(() =>
            {
                slot.inputData.isEquiped = true;
                slot.ChangeEquip();
            });
        }
    }
}

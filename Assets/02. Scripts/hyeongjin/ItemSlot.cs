using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using Rito.InventorySystem;
using static UnityEditor.Progress;
using UnityEditorInternal.Profiling.Memory.Experimental;

public class ItemSlot : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    [HideInInspector]public SlotClass slotClass; 
    [SerializeField] private Image _iconImage;
    public InventoryManager inventoryManager;
    public Image itemImage;
    public GameObject EquipMark;
    public ItemClass item;
    private GameObject[] slots;
    public ItemSlot itemslot;
    public GameObject popup;
    public PopupEquip popupEquip;
    public ItemTooltipUI tooltip;
    public int index;
    public RectTransform SlotRect => _slotRect;
    private RectTransform _slotRect;
    public bool IsAccessible => _isAccessibleSlot && _isAccessibleItem;
    public bool HasItem => _iconImage.sprite != null;

    public Image iconimage;
    private bool _isAccessibleSlot = true; // 슬롯 접근가능 여부
    private bool _isAccessibleItem = true; // 아이템 접근가능 여부


    public void Start()
    {
        iconimage = transform.Find("ItemIconImage").GetComponent<Image>();
        item = inventoryManager.items[index].GetItem();
        item.IsEquipped = false;
    }




    public void ChangeEquip(ItemClass items)
    {
        if (items.IsEquipped == true)
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
        if (iconimage.sprite != null)
        {
            if (item.type != Type.key)
            {
                EquipPopup(inventoryManager.items[index].GetItem());
            }
            else
            {
                return;
            }
                
        }       
    }

    public void EquipPopup(ItemClass item)
    {
        SlotClass slot = inventoryManager.Contains(item);
        if (slot != null && slot.GetItem().isStackable == false)
        {
            popup.SetActive(true);
            popupEquip.PopupSetting(this);
        }
        else if (slot != null && slot.GetItem().isStackable)
        {
            inventoryManager.Consume(inventoryManager.items[index].GetItem());
        }
        else
        {
            return;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (iconimage.sprite != null)
        {
            tooltip.gameObject.SetActive(true);
            tooltip.SetupTooltip(inventoryManager.items[index].GetItem().itemName, inventoryManager.items[index].GetItem().tooltip);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
        
    }

    //public void Equipped()
    //{
    //    if (item.isEquiped == false)
    //    {
    //        item.isEquiped = true;
    //    }
    //    else
    //    {
    //        item.isEquiped = false;
    //    }
    //}

}

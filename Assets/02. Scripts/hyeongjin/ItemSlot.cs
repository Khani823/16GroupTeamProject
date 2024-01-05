using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [HideInInspector]public ItemData inputData;
    [HideInInspector]public SlotClass slotClass; 
    [SerializeField] private Image _iconImage;
    public InventoryManager inventoryManager;
    public Image itemImage;
    public GameObject EquipMark;
    private ItemClass item;
    private GameObject[] slots;
    public ItemSlot itemslot;
    public GameObject popup;
    public PopupEquip popupEquip;
    public int index;
    public RectTransform SlotRect => _slotRect;
    private RectTransform _slotRect;
    public bool IsAccessible => _isAccessibleSlot && _isAccessibleItem;
    public bool HasItem => _iconImage.sprite != null;

    public Image iconimage;
    private bool _isAccessibleSlot = true; // 슬롯 접근가능 여부
    private bool _isAccessibleItem = true; // 아이템 접근가능 여부

    // Start is called before the first frame update
    //public void Init(ItemData data)
    //{
    //    inputData = data;
    //    itemImage.sprite = data._iconSprite;
    //    itemImage.enabled = true;

    //    ChangeEquip();
    //}
    public void Start()
    {
        iconimage = transform.Find("ItemIconImage").GetComponent<Image>();
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
        if (iconimage.sprite != null)
        {
            EquipPopup(inventoryManager.items[index].GetItem());
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
}

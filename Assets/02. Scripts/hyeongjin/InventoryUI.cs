using Rito.InventorySystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;
using System.Reflection;

public class InventoryUI : MonoBehaviour
{
    private PointerEventData _ped;
    private ItemSlot itemslot;
    private ItemClass itemclass;
    public ItemTooltipUI _itemTooltip;
    public InventoryManager _inventoryManager;
    [SerializeField] private bool _showHighlight = true;
    [SerializeField] private bool _showTooltip = true;
    private List<RaycastResult> _rrList;
    private GraphicRaycaster _gr;
    private ItemSlot _pointerOverSlot;


    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        TryGetComponent(out _gr);
        if (_gr == null)
            _gr = gameObject.AddComponent<GraphicRaycaster>();

        // Graphic Raycaster
        _ped = new PointerEventData(EventSystem.current);
        _rrList = new List<RaycastResult>(10);

        // Item Tooltip UI
        if (_itemTooltip == null)
        {
            _itemTooltip = GetComponentInChildren<ItemTooltipUI>();
        }
    }
    private void Update()
    {
        _ped.position = Input.mousePosition;


        if (_showTooltip) ShowOrHideItemTooltip(_inventoryManager.items[1].GetItem());

    }
    private T RaycastAndGetFirstComponent<T>() where T : Component
    {
        _rrList.Clear();

        _gr.Raycast(_ped, _rrList);

        if (_rrList.Count == 0)
            return null;

        return _rrList[0].gameObject.GetComponent<T>();
    }

    //private void OnPointerEnterAndExit()
    //{
    //    // 이전 프레임의 슬롯
    //    var prevSlot = itemslot;

    //    // 현재 프레임의 슬롯
    //    var curSlot = itemslot = RaycastAndGetFirstComponent<ItemSlot>();

    //    if (prevSlot == null)
    //    {
    //        // Enter
    //        if (curSlot != null)
    //        {
    //            OnCurrentEnter();
    //        }
    //    }
    //    else
    //    {
    //        // Exit
    //        if (curSlot == null)
    //        {
    //            OnPrevExit();
    //        }

    //        // Change
    //        else if (prevSlot != curSlot)
    //        {
    //            OnPrevExit();
    //            OnCurrentEnter();
    //        }
    //    }
    //    void OnCurrentEnter()
    //    {
    //        if (_showHighlight)
    //            curSlot.Highlight(true);
    //    }
    //    void OnPrevExit()
    //    {
    //        prevSlot.Highlight(false);
    //    }
    //}


    private void ShowOrHideItemTooltip(ItemClass item)
    {
        SlotClass slot = _inventoryManager.Contains(item);
        // 마우스가 유효한 아이템 아이콘 위에 올라와 있다면 툴팁 보여주기
        if (slot != null)
        {
            _itemTooltip.Hide();
        }
        else
        {

            UpdateTooltipUI(itemslot);
            _itemTooltip.Show();
        }
        Debug.Log(slot);
    }

    //private void ShowOrHideItemTooltip()
    //{
    //    // 마우스가 유효한 아이템 아이콘 위에 올라와 있다면 툴팁 보여주기
    //    bool isValid =
    //        itemslot != null && itemslot.HasItem && itemslot.IsAccessible;
    //    if (isValid)
    //    {
    //        _itemTooltip.Hide();
    //    }
    //    else
    //    {

    //        UpdateTooltipUI(itemslot);
    //        _itemTooltip.Show();
    //    }
    //    Debug.Log(itemslot);
    //}




    /// <summary> 툴팁 UI의 슬롯 데이터 갱신 </summary>
    private void UpdateTooltipUI(ItemSlot slot)
        {
            // 툴팁 정보 갱신
            _itemTooltip.SetItemInfo(_inventoryManager.items[itemslot.index].GetItem());

            // 툴팁 위치 조정
            _itemTooltip.SetRectPosition(slot.SlotRect);
        }
    } 


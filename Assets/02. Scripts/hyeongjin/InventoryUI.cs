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


        //if (_showTooltip) ShowOrHideItemTooltip(_inventoryManager.items[1].GetItem());

    }
    private T RaycastAndGetFirstComponent<T>() where T : Component
    {
        _rrList.Clear();

        _gr.Raycast(_ped, _rrList);

        if (_rrList.Count == 0)
            return null;

        return _rrList[0].gameObject.GetComponent<T>();
    }


    
    private void UpdateTooltipUI(ItemSlot slot)
        {
            // 툴팁 정보 갱신
            _itemTooltip.SetItemInfo(_inventoryManager.items[itemslot.index].GetItem());

            // 툴팁 위치 조정
            _itemTooltip.SetRectPosition(slot.SlotRect);
        }
    } 


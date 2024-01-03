using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public ItemSlot[] itemslots;

    public void SetInventory()
    {
        for (int i = 0; i < DataManager.instance.gameData.myItems.Length; i++)
        {
            itemslots[i].Init(DataManager.instance.gameData.myItems[i]);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetInventory();
    }
}

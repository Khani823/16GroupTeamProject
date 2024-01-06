using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectToPickup : MonoBehaviour
{
    [SerializeField] private ItemClass itemclass;
    [SerializeField] private string playerTag;
    public InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        Sprite imagesprite = GetComponent<Sprite>();
        if(itemclass != null) 
        {
            imagesprite = itemclass.itemIcon;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag(playerTag))
        {
            AddToInventoryAndDestoryThis(itemclass);
        }
    }

    // Update is called once per frame
    private void AddToInventoryAndDestoryThis(ItemClass itemclass)
    {
        inventoryManager.Add(itemclass);
        Destroy(gameObject);
    }
}

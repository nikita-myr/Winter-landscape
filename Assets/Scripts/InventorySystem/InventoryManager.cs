using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    
    private void Awake()
    {
        instance = this;
    }

    public bool AddItem(Item item)
    {
        //Check for the same item in slots
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && item.isStackable && itemInSlot.count < item.stackSize)
            {
                itemInSlot.count++;
                itemInSlot.RefresTexts();
                return true;
            }
        }
        
        //Check for empty slots
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        
        // Make game can append new slots and place new item in this 
        return false;
    }

    public bool StackItems(InventoryItem movedItem, InventorySlot slot)
    {
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (movedItem.item.isStackable && movedItem.item.type == itemInSlot.item.type &&
            movedItem.item.stackSize > itemInSlot.count)
        {
            itemInSlot.count += movedItem.count;
            itemInSlot.RefresTexts();
            return true;
        }
        return false;
    }
    
    public void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGO = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGO.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
    
}

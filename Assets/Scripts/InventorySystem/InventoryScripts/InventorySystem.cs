using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;


[System.Serializable]
public class InventorySystem
{
    [SerializeField] private List<InventorySlot> inventorySlots;

    public List<InventorySlot> InventorySlots => inventorySlots;

    public int InventorySize => InventorySlots.Count;

    public UnityAction<InventorySlot> OnInventorySlotChanged;

    public InventorySystem(int size)
    {
        inventorySlots = new List<InventorySlot>(size);

        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddToInventory(ItemData itemToAdd, int amountToAdd)
    {
        if (ContainsItem(itemToAdd, out List<InventorySlot> invSlots))
        {
            foreach (var slot in invSlots)
            {
                if (slot.RoomLeftInStack(amountToAdd))
                {
                    slot.AddToStack(amountToAdd);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }
        }
        
        if (HasFreeSlot(out InventorySlot freeSlot))
        {
            freeSlot.UpdateInvenorySlot(itemToAdd, amountToAdd);
            OnInventorySlotChanged?.Invoke(freeSlot);
            return true;
        }
        /*else    FOR ADDING NEW SLOT IF NO FREE SLOTS IN 
        {
            inventorySlots.Add(new InventorySlot());
            HasFreeSlot(out InventorySlot newFreeSlot);
            newFreeSlot.UpdateInvenorySlot(itemToAdd, amountToAdd);
            OnInventorySlotChanged?.Invoke(newFreeSlot);
            return true;
        }*/

        return false;
    }

    public bool ContainsItem(ItemData itemToAdd, out List<InventorySlot> invSlots)
    {
        invSlots = InventorySlots.Where(i => i.ItemData == itemToAdd).ToList();

        return invSlots != null ? true : false;
    }

    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null);
        return freeSlot != null ? true : false;
    }

}

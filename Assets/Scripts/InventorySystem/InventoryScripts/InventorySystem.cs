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

    public InventorySystem(int size) // Constructor that sets the amount of slots.
    {
        inventorySlots = new List<InventorySlot>(size);

        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddToInventory(ItemData itemToAdd, int amountToAdd)
    {
        if (ContainsItem(itemToAdd, out List<InventorySlot> invSlots)) // Check whether item exist in inventory.
        {
            foreach (var slot in invSlots)
            {
                if (slot.EnoughRoomLeftInStack(amountToAdd))
                {
                    slot.AddToStack(amountToAdd);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }
        }
        
        if (HasFreeSlot(out InventorySlot freeSlot)) // Gets the first available slot.
        {
            if (freeSlot.EnoughRoomLeftInStack(amountToAdd))
            {
                freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
                OnInventorySlotChanged?.Invoke(freeSlot);
                return true;
            }
            // Add implementation to only take what can fill the stack, and check for another free slot to put the remainder in.
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

    public bool ContainsItem(ItemData itemToAdd, out List<InventorySlot> invSlots) // Does do any of our slots have item to add in them?
    {
        invSlots = InventorySlots.Where(i => i.ItemData == itemToAdd).ToList(); // If they do, get list of all of them.
        return invSlots != null ? true : false; // If they do, return true, if not return false.
    }

    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null); // Get the first free slot.
        return freeSlot != null ? true : false;
    }

}

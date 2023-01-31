using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    [SerializeField] private ItemData itemData; // Reference to the data.
    [SerializeField] private int stackSize; //Current stack size - how many of the date do we have.

    public ItemData ItemData => itemData;
    public int StackSize => stackSize;

    public InventorySlot(ItemData source, int amount) // Constructor to make a occupied inventory slot.
    {
        itemData = source;
        stackSize = amount;
    }

    public InventorySlot() // Constructor to make an empty inventory slot.
    {
        ClearSlot();
    }

    public void ClearSlot() // Clear the slot.
    {
        itemData = null;
        stackSize = -1;
    }

    public void AssignItem(InventorySlot invSlot) // Assigns item to the slot.
    {
        if(itemData == invSlot.ItemData) AddToStack(invSlot.stackSize); //Does the slot contain the same item? Add to stack if so.
        else // Override slot with the inventory slot that we're passing in.
        {
            itemData = invSlot.itemData;
            stackSize = 0;
            AddToStack(invSlot.stackSize);
        }
    }

    public void UpdateInventorySlot(ItemData data, int amount) // Updates slot directly.
    {
        itemData = data;
        stackSize = amount;
    }

    public bool EnoughRoomLeftInStack(int amountToAdd, out int amountRemaining) // Would the be amount room in the stack for the amount we're trying to add.
    {
        amountRemaining = ItemData.MaxStackSize - stackSize;
        return EnoughRoomLeftInStack(amountToAdd);

    }

    public bool EnoughRoomLeftInStack(int amount)
    {
        if (itemData == null || itemData != null && stackSize + amount <= itemData.MaxStackSize) return true;
        else return false;
    }

    public void AddToStack(int amount)
    {
        stackSize += amount;
    }

    public void RemoveFromStack(int amount)
    {
        stackSize -= amount;
    }

    public bool SplitStack(out InventorySlot splitStack)
    {
        if (stackSize <= 1) // Is there enough to actually split? If not - return false. 
        {
            splitStack = null;
            return false;
        }

        int halfStack = Mathf.RoundToInt(stackSize / 2); // Get half the stack.
        RemoveFromStack(halfStack);

        splitStack = new InventorySlot(itemData, halfStack); // Create a copy of this slot witch half the stack size.
        return true;

    }



}

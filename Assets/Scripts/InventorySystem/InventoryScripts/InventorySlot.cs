using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private int stackSize;

    public ItemData ItemData => itemData;
    public int StackSize => stackSize;

    public InventorySlot(ItemData source, int amount)
    {
        itemData = source;
        stackSize = amount;
    }

    public InventorySlot()
    {
        ClearSlot();
    }

    public void ClearSlot()
    {
        itemData = null;
        stackSize = -1;
    }

    public void UpdateInvenorySlot(ItemData data, int amount)
    {
        itemData = data;
        stackSize = amount;
    }

    public bool RoomLeftInStack(int amountToAdd, out int AmountRemaining)
    {
        AmountRemaining = ItemData.MaxStackSize - stackSize;
        return RoomLeftInStack(amountToAdd);

    }

    public bool RoomLeftInStack(int amount)
    {
        if (stackSize + amount <= itemData.MaxStackSize) return true;
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



}

using UnityEngine;

/// <summary>
/// This is a scriptable object that defines what an item is in game.
/// It could be inherited from to have branches version of items, for example: equipment, food.
/// </summary>

[CreateAssetMenu(menuName = "Inventory system/Item")]
public class ItemData : ScriptableObject
{
    public string DisplayName;
    public Sprite Image;
    public GameObject itemPrefab;
    
    [SerializeField]
    public ItemType Type;
    
    public float Condition;
    public float Weight;
    
    public int MaxStackSize;
    
    [TextArea(4,4)]
    public string Description;
    
}

public enum ItemType
{
    Other,
    Food,
    Water,
    Weapon,
    Tool,
    Medicine,
    Clothes,
}


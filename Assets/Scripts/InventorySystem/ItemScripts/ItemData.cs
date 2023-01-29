using UnityEngine;


[CreateAssetMenu(menuName = "Inventory system/Item")]
public class ItemData : ScriptableObject
{
    public string DisplayName;
    public Sprite Image;
    
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


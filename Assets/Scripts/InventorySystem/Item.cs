using UnityEngine;


[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    public Sprite image;
    
    [SerializeField]
    public ItemType type;
    
    public float condition;
    public float weight;
    public bool isStackable;
    public int stackSize;

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


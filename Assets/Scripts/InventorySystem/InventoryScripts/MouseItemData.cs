using UnityEngine;
using UnityEngine.UI;

public class MouseItemData : MonoBehaviour
{
    public Image ItemSprite;
    public Text ItemCount;


    public void Awake()
    {
        ItemSprite.color = Color.clear;
        ItemCount.text = "";
    }
}

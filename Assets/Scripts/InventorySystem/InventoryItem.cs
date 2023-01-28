using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [Header("UI")]
    public Image image;
    public Text countText;
    public Text weightText;
    public Text conditionText;
    public GameObject inventoryItemPrefab;
    
    public Item item;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public int count = 1;

    private void Awake()
    {
        InitialiseItem(item);
    }


    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefresTexts();
    }

    public void RefresTexts()
    {
        weightText.text = "W-" + item.weight;
        conditionText.text = "C-" + item.condition;
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            /*
             * this void will be using for:
             * 1. Dropping items on the ground (if right mouse button)
             * 2. Use items (if left mouse button) // may be for select items
             *                                        after that, in opened window
             *                                        player can use item or inspect this 
             */
            return;
        }
    }
    
    
}

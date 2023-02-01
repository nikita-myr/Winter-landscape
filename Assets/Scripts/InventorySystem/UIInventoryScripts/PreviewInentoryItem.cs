using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class PreviewInentoryItem : MonoBehaviour, IDragHandler
{
    [SerializeField] private InventoryDisplay _inventoryDisplay;
    private GameObject _itemPrefab;
    private float rotationSpeed = 0.5f;
    
    private void Start()
    {
        _inventoryDisplay.OnSlotClicked += InventorySlot_UI_Clicked;
    }
    
    void InventorySlot_UI_Clicked(object sender, ItemData itemData)
    {
        PreviewItem(itemData);
    }

    public void PreviewItem(ItemData itemToPreview)
    {
        if (_itemPrefab != null)
        {
            Destroy(_itemPrefab.gameObject);
        } 
        
        if (_itemPrefab == null)
        {
            _itemPrefab = Instantiate(itemToPreview.itemPrefab, new Vector3(1000,1000,1000), Quaternion.identity);
            _itemPrefab.GetComponent<Rigidbody>().useGravity = false;
        }
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        var axis = Quaternion.AngleAxis(-90f, Vector3.forward) * eventData.delta;
        _itemPrefab.transform.rotation = Quaternion.AngleAxis(eventData.delta.magnitude * rotationSpeed, axis) * _itemPrefab.transform.rotation;
    }
}

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem dragItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            dragItem.parentAfterDrag = transform;
        } else if (transform.childCount != 0)
        {
            InventoryItem dragItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            if (InventoryManager.instance.StackItems(dragItem, gameObject.GetComponent<InventorySlot>()))
            {
                Destroy(dragItem.gameObject);    
            }
        }
    }
    

}

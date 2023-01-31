using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickUp : MonoBehaviour
{
    public float pickUpRadius = 15.0f;
    public ItemData itemData;

    private SphereCollider myCollider;
    
    // TODO: make item pickup system on by a collider. I need made it by an interact by button like a "Press F to pick up".

    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = pickUpRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.transform.GetComponent<InventoryHolder>();
        
        if (!inventory) return;

        if (inventory.InventorySystem.AddToInventory(itemData, 1))
        {
            Destroy(this.gameObject);
        }

    }
}

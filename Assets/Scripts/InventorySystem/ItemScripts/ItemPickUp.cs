using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshCollider))]
public class ItemPickUp : MonoBehaviour, IInteractable
{
    public ItemData itemData;
    public InventoryHolder inventoryHolder;
    [SerializeField] private string _prompt; 
    public string InteractionPrompt => _prompt;
    public UnityAction<IInteractable> OnIterationComplite { get; set; }
    
    // TODO: make item pickup system on by a raycast from screen. I need made it by an interact by button like a "Press F to pick up".
    
    public void Interact(Interactor interactor, out bool interactSuccesfull)
    {
        var inventoryHolder = GameObject.FindWithTag("Player").GetComponentInChildren<InventoryHolder>();

        if (!inventoryHolder)
        {
            interactSuccesfull = false;
        }
        
        if (inventoryHolder.InventorySystem.AddToInventory(itemData, 1))
        {
            Destroy(gameObject);
            interactSuccesfull = true;
        }

        interactSuccesfull = false;
    }

    public void EndInteraction()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ChestInventory : InventoryHolder, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public UnityAction<IInteractable> OnIterationComplite { get; set; }
    
    public void Interact(Interactor interactor, out bool interactSuccesfull)
    {
        OnDynamicInventoryDisplayRequested?.Invoke(inventorySystem);
        interactSuccesfull = true;
        
    }

    public void EndInteraction()
    {

    }
}

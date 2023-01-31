using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IInteractable 
{
    public UnityAction<IInteractable> OnIterationComplite { get; set; }

    public void Interact(Interactor interactor, out bool interactSuccesfull);
    public void EndInteraction();

}

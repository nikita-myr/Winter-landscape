using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public Transform InteractionPoit;
    public LayerMask InteractionLayer;
    public float InteractionPointRadius = 1.0f;
    public bool isInteracting { get; private set; }

    private void Update()
    {
        var colliders = Physics.OverlapSphere(InteractionPoit.position, InteractionPointRadius, InteractionLayer);

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                var interactable = colliders[i].GetComponent<IInteractable>();
                if (interactable != null) StartInteraction(interactable);
            }
        }
    }

    void StartInteraction(IInteractable interactable)
    {
        interactable.Interact(this, out bool interactSuccesfull);
        isInteracting = true;
    }

    void EndInterction()
    {
        isInteracting = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class InventoryUIController : MonoBehaviour
{
    public GameObject parentDynamicInventoryPanel;
    public DynamicInventoryDisplay inventoryPanel;

    public GameObject paretnPreviewInventoryItem;
    public PreviewInentoryItem previewInventoryItem;

    private void Awake()
    {
        paretnPreviewInventoryItem.gameObject.SetActive(true);
        parentDynamicInventoryPanel.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequested += DisplayInventory;
    }

    private void OnDisable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequested -= DisplayInventory;
    }

    void Update()
    {
        if (inventoryPanel.gameObject.activeInHierarchy && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            parentDynamicInventoryPanel.gameObject.SetActive(false);
            paretnPreviewInventoryItem.gameObject.SetActive(true);
        }
            

    }

    void DisplayInventory(InventorySystem invToDisplay)
    {
        parentDynamicInventoryPanel.gameObject.SetActive(true);
        paretnPreviewInventoryItem.gameObject.SetActive(false);
        inventoryPanel.RefreshDynamicInventory(invToDisplay);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManagerNetwork : NetworkBehaviour
{
    public PlayerInputActions input;
    private PlayerInput playerInput;

    [SerializeField] private bool isOpen = false;
    [SerializeField] private GameObject inventoryCanvas;

    public override void OnNetworkSpawn()
    {
        input = new PlayerInputActions();
        playerInput = GetComponent<PlayerInput>();

        input.Menu.Enable();
        input.Menu.Inventory.performed += Inventory;

        inventoryCanvas.SetActive(false);
        isOpen = false;
    }

    private void Inventory(InputAction.CallbackContext obj)
    {
        if (isOpen)
        {
            inventoryCanvas.SetActive(true);
            isOpen = true;
        }
        else
        {
            inventoryCanvas.SetActive(false);
            isOpen = false;
        }
    }
}
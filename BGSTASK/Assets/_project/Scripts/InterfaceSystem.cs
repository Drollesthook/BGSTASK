using _project.Scripts.Infrastructure;

using UnityEngine;
using UnityEngine.InputSystem;

public class InterfaceSystem
{
    private Canvas _inventoryCanvas;
    private Canvas _shopCanvas;
    private CustomInput _input;

    public InterfaceSystem()
    {
        _input = Game.CustomInput;
        _input.Inventory.Enable();
        _input.Inventory.ToggleInventory.performed += ToggleInventoryHud;
    }

    public void SetInventoryCanvas(GameObject inventoryHudPrefab)
    {
        _inventoryCanvas = inventoryHudPrefab.GetComponent<Canvas>();
    }

    private void OnDispose()
    {
        _input.Inventory.Enable();
        _input.Inventory.ToggleInventory.performed -= ToggleInventoryHud;
    }

    private void ToggleInventoryHud(InputAction.CallbackContext value)
    {
        _inventoryCanvas.enabled = !_inventoryCanvas.isActiveAndEnabled;
    }
}

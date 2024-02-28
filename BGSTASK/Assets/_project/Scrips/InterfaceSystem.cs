using System;

using UnityEngine;
using UnityEngine.InputSystem;

public class InterfaceSystem : MonoBehaviour
{
    [SerializeField] private Canvas _inventoryCanvas;

    private CustomInput _input;

    private void Awake()
    {
        _input = new CustomInput(); //переделать в один инпут
    }

    private void OnEnable()
    {
        _input.Inventory.Enable();
        _input.Inventory.ToggleInventory.performed += ToggleInventoryHud;
    }

    private void OnDisable()
    {
        _input.Inventory.Enable();
        _input.Inventory.ToggleInventory.performed -= ToggleInventoryHud;
    }

    private void ToggleInventoryHud(InputAction.CallbackContext value)
    {
        _inventoryCanvas.enabled = !_inventoryCanvas.isActiveAndEnabled;
    }
}

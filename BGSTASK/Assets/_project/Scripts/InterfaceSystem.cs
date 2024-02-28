using System;
using _project.Scripts.Infrastructure;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _project.Scripts
{
    public class InterfaceSystem : IDisposable
    {
        private Canvas _inventoryCanvas;
        private Canvas _shopCanvas;
        private InputSystem _inputSystem;

        public InterfaceSystem()
        {
            _inputSystem = Game.InputSystem;
            _inputSystem.Interface.Enable();
            _inputSystem.Interface.ToggleInventory.performed += ToggleInventoryHud;
        }

        public void SetInventoryCanvas(GameObject inventoryHudPrefab)
        {
            _inventoryCanvas = inventoryHudPrefab.GetComponent<Canvas>();
        }

        private void ToggleInventoryHud(InputAction.CallbackContext value)
        {
            _inventoryCanvas.enabled = !_inventoryCanvas.isActiveAndEnabled;
        }

        public void Dispose()
        {
            _inputSystem.Interface.Disable();
            _inputSystem.Interface.ToggleInventory.performed -= ToggleInventoryHud;
        }
    }
}

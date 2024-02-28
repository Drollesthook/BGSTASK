using System;
using _project.Scripts.Infrastructure;
using _project.Scripts.Merchant;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _project.Scripts
{
    public class InterfaceSystem : IDisposable
    {
        private Canvas _inventoryCanvas;
        private Canvas _shopCanvas;
        private InputSystem _inputSystem;
        private MerchantBehavior _merchantBehavior;

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
        
        public void SetShopCanvas(GameObject shopHudPrefab)
        {
            _shopCanvas = shopHudPrefab.GetComponent<Canvas>();
        }

        public void SubscribeToMerchant(MerchantBehavior merchantBehavior)
        {
            _merchantBehavior = merchantBehavior;
            _merchantBehavior.OnPlayerWalkedInRange += SubscribeToInteractButton;
            _merchantBehavior.OnPlayerWalkedOutOfRange += UnsubscribeFromInteractButton;
        }

        private void ToggleInventoryHud(InputAction.CallbackContext value)
        {
            _inventoryCanvas.enabled = !_inventoryCanvas.isActiveAndEnabled;
        }

        private void ToggleShopHud(InputAction.CallbackContext value)
        {
            _shopCanvas.enabled = !_shopCanvas.isActiveAndEnabled;
        }

        private void SubscribeToInteractButton()
        {
            _inputSystem.Interface.ToggleShop.performed += ToggleShopHud;
        }
        
        private void UnsubscribeFromInteractButton()
        {
            _inputSystem.Interface.ToggleShop.performed -= ToggleShopHud;
            _shopCanvas.enabled = false;
        }

        public void Dispose()
        {
            _inputSystem.Interface.Disable();
            _inputSystem.Interface.ToggleInventory.performed -= ToggleInventoryHud;
            _merchantBehavior.OnPlayerWalkedInRange -= SubscribeToInteractButton;
            _merchantBehavior.OnPlayerWalkedOutOfRange -= UnsubscribeFromInteractButton;
        }
    }
}

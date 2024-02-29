using System;

using _project.Scripts.Character;
using _project.Scripts.Configs;
using _project.Scripts.Infrastructure;
using _project.Scripts.Merchant;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace _project.Scripts.Inventory
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TMP_Text _amountText;
        
        private TypeOfItem _typeOfItem;
        private int _price;
        private int _amount;
        private Sprite _icon;
        private AnimatorOverrideController _overrideController;
        private CharacterSkinSystem _characterSkinSystem;
        

        private void Start()
        {
            _characterSkinSystem = Game.CharacterSkinSystem;
        }

        public void WearSkin()
        {
            if(_overrideController == null) return;
            _characterSkinSystem.SetNewAnimationOverride(_overrideController);
        }

        public void FillItem(ShopItemCfg config)
        {
            ToggleVisual(true);
            _typeOfItem = config.type;
            _price = config.price;
            _amount = config.amount;
            _icon = config.icon;
            if (config.animatorOverride != null)
                _overrideController = config.animatorOverride;
            SetVisual();
        }

        public void FillEmpty()
        {
            ToggleVisual(false);
        }

        private void ToggleVisual(bool active)
        {
            _iconImage.gameObject.SetActive(active);
            _amountText.gameObject.SetActive(active);
        }
    
        private void SetVisual()
        {
            _iconImage.sprite = _icon;
            _amountText.SetText(_amount.ToString());
        }
    }
}

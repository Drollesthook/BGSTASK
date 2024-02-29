using _project.Scripts.Configs;
using _project.Scripts.Infrastructure;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace _project.Scripts.Merchant
{
    public class SellShopItem : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private TMP_Text _amountText;
        
        private TypeOfItem _typeOfItem;
        private int _price;
        private int _amount;
        private Sprite _icon;
        private AnimatorOverrideController _overrideController;
        
        
        public void SellItem()
        {
            Debug.Log("click to sell" + _typeOfItem);
            Game.CharacterInventorySystem.RemoveItemFromList(_typeOfItem);
        }

        public void FillItem(ShopItemCfg config)
        {
            ToggleVisual(true);
            _typeOfItem = config.type;
            _price = config.price;
            _amount = config.amount;
            _icon = config.icon;
            if (_typeOfItem == TypeOfItem.Cloth)
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
            _priceText.gameObject.SetActive(active);
            _amountText.gameObject.SetActive(active);
        }
    
        private void SetVisual()
        {
            _iconImage.sprite = _icon;
            _priceText.SetText(_price.ToString());
            _amountText.SetText(_amount.ToString());
        }
    }
}

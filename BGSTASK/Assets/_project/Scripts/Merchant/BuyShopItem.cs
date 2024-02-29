using _project.Scripts.Configs;
using _project.Scripts.Infrastructure;

using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace _project.Scripts.Merchant
{
    public class BuyShopItem : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private TMP_Text _amountText;
        [SerializeField] private Image _checkMark;
        
        private TypeOfItem _typeOfItem;
        private int _price;
        private int _amount;
        private Sprite _icon;
        private AnimatorOverrideController _overrideController;
        
        
        public void BuyItem()
        {
            Debug.Log("click to buy" + _typeOfItem);
            if (!Game.CharacterInventorySystem.CanIBuyIt(_price) || _amount < 1) return;
            _amount--;
            SetVisual();
            Game.CharacterInventorySystem.AddItemToTheList(new ShopItemCfg(_price, 1, _typeOfItem, _icon, _overrideController));
        }

        public void FillItem(ShopItemCfg config)
        {
            _typeOfItem = config.type;
            _price = config.price;
            _amount = config.amount;
            _icon = config.icon;
            if (_typeOfItem == TypeOfItem.Cloth)
                _overrideController = config.animatorOverride;
            SetVisual();
        }

        private void CheckAmount()
        {
            _checkMark.gameObject.SetActive(_amount < 1);
        }

        private void SetVisual()
        {
            _iconImage.sprite = _icon;
            _priceText.SetText(_amount < 1 ? "Out of stock" : _price.ToString());
            _amountText.SetText(_amount.ToString());
            CheckAmount();
        }
    }
}
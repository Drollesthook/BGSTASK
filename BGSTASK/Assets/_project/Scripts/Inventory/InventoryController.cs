using System.Collections.Generic;

using _project.Scripts.Character;
using _project.Scripts.Configs;
using _project.Scripts.Infrastructure;

using TMPro;

using UnityEngine;

namespace _project.Scripts.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _goldText;

        private CharacterInventorySystem _characterInventorySystem;
        
        private void Start()
        {
            _characterInventorySystem = Game.CharacterInventorySystem;
            _characterInventorySystem.OnInventoryChanged += SetItemsInShop;
            SetItemsInShop();
        }

        private void OnDestroy()
        {
            _characterInventorySystem.OnInventoryChanged -= SetItemsInShop;
        }

        private void SetItemsInShop()
        {
            _goldText.SetText(_characterInventorySystem.MoneyAmount.ToString());
            List<ShopItemCfg> items = _characterInventorySystem.GetListOfItems();
            var listOfShopItems = GetComponentsInChildren<InventoryItem>();
            for (int i = 0; i < items.Count; i++)
            {
                listOfShopItems[i].FillItem(items[i]);
            }

            for (int i = items.Count; i < listOfShopItems.Length; i++)
            {
                listOfShopItems[i].FillEmpty();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using _project.Scripts.Configs;
using _project.Scripts.Infrastructure;

using UnityEngine;

namespace _project.Scripts.Merchant
{
    public class SellShopController : MonoBehaviour
    {
        private void Start()
        {
            Game.CharacterInventorySystem.OnInventoryChanged += SetItemsInShop;
        }

        private void OnDestroy()
        {
            Game.CharacterInventorySystem.OnInventoryChanged -= SetItemsInShop;
        }

        private void SetItemsInShop()
        {
            List<ShopItemCfg> items = Game.CharacterInventorySystem.GetListOfItems();
            var listOfShopItems = GetComponentsInChildren<SellShopItem>();
            Debug.Log(items.Count);
            Debug.Log(listOfShopItems.Length);
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

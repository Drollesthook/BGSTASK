﻿using System;
using System.Collections.Generic;

using _project.Scripts.Configs;

namespace _project.Scripts.Character
{
    public class CharacterInventorySystem
    {
        public event Action OnInventoryChanged;
        public int MoneyAmount => moneyAmount;

        private List<ShopItemCfg> listOfItems = new List<ShopItemCfg>();
        private int moneyAmount = 1000;

        public bool CanIBuyIt(int price)
        {
            return moneyAmount >= price;
        }

        public List<ShopItemCfg> GetListOfItems()
        {
            return listOfItems;
        }

        public void AddItemToTheList(ShopItemCfg newItem)
        {
            foreach (var item in listOfItems)
            {
                if (item.type == newItem.type)
                {
                    item.amount++;
                    break;
                } else
                {
                    listOfItems.Add(newItem);
                }
            }

            moneyAmount -= newItem.price;
            OnInventoryChanged?.Invoke();
        }

        public void RemoveItemFromList(TypeOfItem type)
        {
            foreach (var item in listOfItems)
            {
                if (item.type == type)
                {
                    item.amount--;
                    moneyAmount += item.price;
                    if (item.amount == 0)
                        listOfItems.Remove(item);
                    break;
                }
            }
            OnInventoryChanged?.Invoke();
        }
    }
}
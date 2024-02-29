using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

namespace _project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "NewShopConfig", menuName = "Items/ShopItem")]
    public class ShopItemsConfig : ScriptableObject
    {
        public List<ShopItemCfg> items = new List<ShopItemCfg>();
    }

    [Serializable]
    public class ShopItemCfg
    {
        public ShopItemCfg(int price, int amount, TypeOfItem type, Sprite icon, AnimatorOverrideController animatorOverride)
        {
            this.price = price;
            this.amount = amount;
            this.type = type;
            this.icon = icon;
            this.animatorOverride = animatorOverride;
        }
        public int price;
        public int amount;
        public TypeOfItem type;
        public Sprite icon;
        public AnimatorOverrideController animatorOverride;
    }
}

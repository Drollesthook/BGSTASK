using System;
using System.Collections.Generic;
using UnityEngine;

namespace _project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "NewShopConfig", menuName = "Items/ShopItem")]
    public class ShopItemsConfig : ScriptableObject
    {
        public List<ShopItemCfg> items = new List<ShopItemCfg>();
    }

    [Serializable]
    public struct ShopItemCfg
    {
        public int price;
        public int amount;
        public TypeOfItem type;
        public Sprite icon;
        public AnimatorOverrideController animatorOverride;
    }
}

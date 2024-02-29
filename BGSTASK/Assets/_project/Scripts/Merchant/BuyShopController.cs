using _project.Scripts.Configs;

using UnityEngine;

namespace _project.Scripts.Merchant
{
    public class BuyShopController : MonoBehaviour
    {
        [SerializeField] private ShopItemsConfig itemsConfig;

        private void Start()
        {
            SetItemsInShop();
        }

        private void SetItemsInShop()
        {
            var listOfShopItems = GetComponentsInChildren<BuyShopItem>();
            Debug.Log(itemsConfig.items.Count);
            Debug.Log(listOfShopItems.Length);
            for (int i = 0; i < itemsConfig.items.Count; i++)
            {
                listOfShopItems[i].FillItem(itemsConfig.items[i]);
            }
        }
    }
}

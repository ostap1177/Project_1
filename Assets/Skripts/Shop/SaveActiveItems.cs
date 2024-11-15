using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    public class SaveActiveItems : MonoBehaviour
    {
        [SerializeField] private List<ShopItem> _shopItem = new List<ShopItem>();

        private const string ItemName = "ItemName";

        private void OnDisable()
        {
            SeveActiveItem();
        }

        private void SeveActiveItem()
        {
            foreach (var item in _shopItem)
            {
                if (item.IsActive == true)
                {
                    PlayerPrefs.SetString(ItemName, item.Id);
                    PlayerPrefs.Save();
                }
            }
        }
    }
}

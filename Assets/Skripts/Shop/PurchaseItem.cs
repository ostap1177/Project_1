using System.Collections.Generic;
using UnityEngine;
using YG;

namespace Shop
{
    public class PurchaseItem : MonoBehaviour
    {
        [SerializeField] private PurchaseYG[] _purchasesYG = new PurchaseYG[3];

        private List<ShopItem> _listItems = new List<ShopItem>();

        private void OnEnable()
        {
            YandexGame.PurchaseSuccessEvent += SuccessPurchased;
            YandexGame.PurchaseFailedEvent += FailedPurchased;
        }

        private void OnDisable()
        {
            YandexGame.PurchaseSuccessEvent -= SuccessPurchased;
            YandexGame.PurchaseFailedEvent -= FailedPurchased;
        }

        private void Awake()
        {
            FindItem();
        }

        private void Start()
        {
            if (YandexGame.SDKEnabled == true)
            {
                YandexGame.LoadProgress();
                CheckPurchase(YandexGame.savesData.LoadItems());
            }
        }

        public void OpenWindowPayments(string id)
        {
            YandexGame.BuyPayments(id);
        }

        private void CheckPurchase(string[] itemsBuyId)
        {
            foreach (var item in _purchasesYG)
            {
                foreach (var id in itemsBuyId)
                {
                    if (item.data.id == id)
                    {
                        if (item.TryGetComponent(out ShopItem itemBuy))
                        {
                            itemBuy.Purchase();
                        }

                        item.data.consumed = true;
                    }
                }
            }
        }

        private void SuccessPurchased(string id)
        {
            foreach (var item in _purchasesYG)
            {

                if (item.data.id == id)
                {
                    if (item.TryGetComponent(out ShopItem itemBuy))
                    {
                        itemBuy.Purchase();
                        YandexGame.savesData.SaveItem(item.data.id);
                        YandexGame.SaveProgress();
                    }
                }
            }

        }
        private void FindItem()
        {
            foreach (var item in _purchasesYG)
            {
                if (item.TryGetComponent(out ShopItem itemBuy))
                {
                    _listItems.Add(itemBuy);
                }
            }
        }

        private void FailedPurchased(string id)
        {
            // Например, можно открыть уведомление о неуспешности покупки.
        }
    }
}
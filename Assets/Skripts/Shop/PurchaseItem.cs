using System.Collections.Generic;
using UnityEngine;
using YG;

namespace Shop
{
    public class PurchaseItem : MonoBehaviour
    {
        [SerializeField] private ShopItem[] _shopItems = new ShopItem[3];

        private void OnEnable()
        {
            YandexGame.PurchaseSuccessEvent += SuccessPurchased;
            YandexGame.PurchaseFailedEvent += FailedPurchased;

            YandexGame.ConsumePurchases();
        }

        private void OnDisable()
        {
            YandexGame.PurchaseSuccessEvent -= SuccessPurchased;
            YandexGame.PurchaseFailedEvent -= FailedPurchased;
        }

        private void Awake()
        {
            StartCoroutine(YandexPurchaseSpriteHolder.Get(null));
        }

        private void Start()
        {
            if (YandexGame.SDKEnabled == true)
            {
                YandexGame.LoadProgress();
                CheckPurchase(YandexGame.savesData.LoadItems());
            }
        }

       /* private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ReteunPurchase();
            }
        }*/


        public void OpenWindowPayments(string id)
        {
            YandexGame.BuyPayments(id);
        }

        private void CheckPurchase(string[] itemsBuyId)
        {
            foreach (var item in _shopItems)
            {
                foreach (var id in itemsBuyId)
                {
                    if (item.Id == id)
                    {
                        item.Purchase();
                    }
                }
            }
        }

        private void SuccessPurchased(string id)
        {
            foreach (var item in _shopItems)
            {

                if (item.Id == id)
                {
                    if (item.TryGetComponent(out ShopItem itemBuy))
                    {
                        itemBuy.Purchase();
                        YandexGame.savesData.SaveItem(item.Id);
                        YandexGame.SaveProgress();
                    }
                }
            }

            YandexGame.ConsumePurchaseByID(id);
        }
/*        private void FindItem()
        {
            foreach (var item in _purchasesYG)
            {
                if (item.TryGetComponent(out ShopItem itemBuy))
                {
                    _listItems.Add(itemBuy);
                }
            }
        }*/

        private void FailedPurchased(string id)
        {
            // Например, можно открыть уведомление о неуспешности покупки.
        }

        private void ReteunPurchase()
        {
            YandexGame.ResetSaveProgress();
            Debug.Log("ResretSave");

            foreach (var item in _shopItems)
            {
               item.Refund();
            }

            YandexGame.SaveProgress();
        }
    }
}
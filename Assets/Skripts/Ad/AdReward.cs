using System.Security.Principal;
using UnityEngine;
using UnityEngine.Events;
using YG;

namespace Ad
{
    public class AdReward : MonoBehaviour
    {
        private int _idEntity;

        public event UnityAction DropedManikin;
        public event UnityAction BuildedBarrier;
        public event UnityAction BoostedBarrier;
        public event UnityAction ErrorVideo;

        public void Reward(int idEntity)
        {
            Closed();

            YandexGame.RewVideoShow(idEntity);
            Time.timeScale = 0;
            _idEntity = idEntity;

            Open();
        }

        private void OnErrorVideoEvent()
        {
            Closed();

            Time.timeScale = 1;
            ErrorVideo?.Invoke();
        }

        private void OnRewardVideoEvent(int id)
        {
            Closed();

            switch (id)
            {
                case 1:
                    DropedManikin?.Invoke();
                    break;
                case 2:
                    BuildedBarrier?.Invoke();
                    break;
                case 3:
                    BoostedBarrier?.Invoke();
                    break;
            }
        }

        private void Open()
        {
            YandexGame.ErrorVideoEvent += OnErrorVideoEvent;
            YandexGame.RewardVideoEvent += OnRewardVideoEvent;
        }

        private void Closed()
        {
            YandexGame.ErrorVideoEvent -= OnErrorVideoEvent;
            YandexGame.RewardVideoEvent -= OnRewardVideoEvent;

            ErrorVideo?.Invoke();
        }
    }
}

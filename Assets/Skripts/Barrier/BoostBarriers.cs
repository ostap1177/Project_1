using UnityEngine;
using Entity;
using Ui;

namespace BarriersEntity
{
    public class BoostBarriers : EntityBuying
    {
        [Space(10)]
        [SerializeField] private float _socondTime = 5f;
        [SerializeField] private int _boostMultiplier = 2;
        [SerializeField] private Switcher _switcher;
        [SerializeField] private Timer _timer;

        private bool _isActive = false;
        private int _normalMultiplaer = 1;

        public int BoostCost => _cost;
        public bool IsActive => _isActive;

        private void OnEnable()
        {
            _buttonClicker.BoostedBarriers += OnBoost;
            _reward.BoostedBarrier += OnRewarded;
            _reward.ErrorVideo += OnErrorVideo;
            _timer.EndTime += OnEndTime;
        }

        private void OnDisable()
        {
            _buttonClicker.BoostedBarriers -= OnBoost;
            _reward.BoostedBarrier -= OnRewarded;
            _reward.ErrorVideo -= OnErrorVideo;
            _timer.EndTime -= OnEndTime;
        }

        private void Awake()
        {
            _costView.SetText(_cost);
        }

        override public void AdView(bool isView)
        {
            if (_isActive == false)
            {
                _costView.EnableText(!isView);
                _costView.EnableImage(isView);
            }
            else
            {
                _costView.EnableText(false);
                _costView.EnableImage(false);
            }
        }

        private void OnErrorVideo()
        {
            _costView.EnableText(true);
            _costView.EnableImage(false);

            _isActive = false;
        }

        private void OnBoost()
        {
            if (_isActive == false)
            {
                OnCreate();
            }
        }

        private void OnEndTime()
        {
            _isActive = false;
            _costView.EnableText(true);
            _switcher.SetSpeedActiveBarriers(_normalMultiplaer);
        }

        override protected void EntityCreate()
        {
            _isActive = true;

            _costView.EnableText(false);
            _costView.EnableImage(false);
            _timer.CountingDown(_socondTime);
            _switcher.SetSpeedActiveBarriers(_boostMultiplier);
        }
    }
}
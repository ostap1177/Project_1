using UnityEngine;
using Ad;
using Ui;
using UiView;

namespace Entity
{
    public abstract class EntityBuying : MonoBehaviour
    {
        [SerializeField] protected ScoreCounter _scoreCounter;
        [SerializeField] protected ButtonClicker _buttonClicker;
        [SerializeField] protected CostView _costView;
        [SerializeField] protected int _cost = 100;
        [SerializeField] protected float _costMultiplier = 1.1f;
        [SerializeField] protected AdReward _reward;
        [SerializeField] protected int _idEntity;

        public int Cost => _cost;

        virtual public void AdView(bool isView)
        {
            _costView.EnableText(!isView);
            _costView.EnableImage(isView);
        }

        abstract protected void EntityCreate();

        protected void OnCreate()
        {
            if (_scoreCounter.TryRemovePoint(_cost))
            {
                EntityCreate();
                ChangePrice();
            }
            else
            {
                _reward.Reward(_idEntity);
            }
        }

        protected void OnRewarded()
        {
            EntityCreate();
        }

        protected void ChangePrice()
        {
            float tempValue = (float)_cost * _costMultiplier;

            _cost = (int)tempValue;
            _costView.SetText(_cost);
        }
    }
}

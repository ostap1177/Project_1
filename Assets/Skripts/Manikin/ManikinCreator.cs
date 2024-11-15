using System.Collections.Generic;
using UnityEngine;
using Entity;

namespace ManikinEntity
{
    public class ManikinCreator : EntityBuying
    {
        [Space(10)]
        [SerializeField] private Manikin _manikinPrefab;
        [SerializeField] private float _leftLimit;
        [SerializeField] private float _rightLimit;

        private Transform _transform;

        public int ManikinCost => _cost;

        private void OnEnable()
        {
            _buttonClicker.DropedManikin += this.OnCreate;
            _reward.DropedManikin += OnRewarded;
        }

        private void OnDisable()
        {
            _buttonClicker.DropedManikin -= this.OnCreate;
            _reward.DropedManikin -= OnRewarded;
        }

        private void Awake()
        {
            _costView.SetText(_cost);
            _transform = transform;
        }

        protected override void EntityCreate()
        {
            float xPosition = Random.Range(_leftLimit, _rightLimit);
            Vector3 position = new Vector3(xPosition, _transform.position.y, _transform.position.z);

            Instantiate(_manikinPrefab.gameObject, position, Quaternion.identity);
        }
    }
}
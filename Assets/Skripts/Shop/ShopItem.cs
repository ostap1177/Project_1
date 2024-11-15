using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private string _id;
        [Space(10)]
        [SerializeField] private Toggle _toggle;
        [SerializeField] private Button _buyButton;

        private string _idDefault = "red";
        private bool _isBuy = false;
        private bool _isActive;

        public string Id => _id;
        public bool IsBuy => _isBuy;
        public bool IsActive => _isActive;

        private void OnEnable()
        {
            _toggle.onValueChanged.AddListener(OnActivate);
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(OnActivate);
        }

        private void Awake()
        {
            if (_id != _idDefault)
            {
                _toggle.gameObject.SetActive(false);
                _toggle.isOn = false;
            }

            if (_isBuy)
            {
                Purchase();
            }
        }

        public void Purchase()
        {
            _isBuy = true;
            _buyButton.gameObject.SetActive(false);
            _toggle.gameObject.SetActive(true);

            Switch(true);
        }

        public void Switch(bool isActive)
        {
            _isActive = isActive;
            _toggle.isOn = isActive;
        }

        private void OnActivate(bool Activate)
        {
            _isActive = _toggle.isOn;
        }
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UiView
{
    public class CostView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Image _image;

        public void SetText(int cost)
        {
            _text.text = cost.ToString();
        }

        public void EnableText(bool enable)
        {
            _text.enabled = enable;
        }

        public void EnableImage(bool enable)
        {
            _image.enabled = enable;
        }
    }
}
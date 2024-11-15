using UnityEngine;

namespace Localization
{
    public class LanguageIdentify : MonoBehaviour
    {
        private const string EnglishCode = "en";

        [SerializeField] private LanguageDefinition _languageDefinition;

        private void Awake()
        {
            _languageDefinition.SaveLanguage(EnglishCode);
        }
    }
}
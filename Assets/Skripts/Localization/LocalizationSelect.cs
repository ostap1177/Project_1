using UnityEngine;
using Lean.Localization;

namespace Localization
{
    public class LocalizationSelect : MonoBehaviour
    {
        private const string English = "en";
        private const string Russian = "ru";
        private const string Turkish = "tr";
        private const string EnglishCode = "English";
        private const string RussianCode = "Russian";
        private const string TurkishCode = "Turkish";

        [SerializeField] private LeanLocalization _leanLocalization;
        [SerializeField] private LanguageDefinition _languageDefinition;

        private void Start()
        {
            ChangeLanguage(_languageDefinition.LoadLanguage());
        }

        public void ChangeLanguage(string languageCode)
        {
            switch (languageCode)
            {
                case English:
                    _leanLocalization.SetCurrentLanguage(EnglishCode);
                    _languageDefinition.SaveLanguage(English);
                    break;
                case Russian:
                    _leanLocalization.SetCurrentLanguage(RussianCode);
                    _languageDefinition.SaveLanguage(Russian);
                    break;
                case Turkish:
                    _leanLocalization.SetCurrentLanguage(TurkishCode);
                    _languageDefinition.SaveLanguage(Turkish);
                    break;
            }
        }
    }
}
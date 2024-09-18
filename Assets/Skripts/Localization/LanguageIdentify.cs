using Agava.YandexGames;
using UnityEngine;

public class LanguageIdentify : MonoBehaviour
{
    private const string EnglishCode = "en";

    [SerializeField] private LanguageDefinition _languageDefinition;

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            _languageDefinition.SaveLanguage(YandexGamesSdk.Environment.i18n.lang);
#else
        _languageDefinition.SaveLanguage(EnglishCode);
#endif
    }
}

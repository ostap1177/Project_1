using System.Collections.Generic;
using UnityEngine;

public class LanguageButton : MonoBehaviour
{
    [SerializeField] private Localization _localization;
    [SerializeField] private LanguageDefinition _languageDefinition;
    [SerializeField] private LocalizationView _localizationView;
    [SerializeField] private List<string> _languageNames = new();
    

    int _index = 0;

    private void Awake()
    {
        _index = _languageNames.IndexOf(_languageDefinition.LoadLanguage());
        SetLangeage();
    }

    public void SetLangeage()
    {
        if(_index >= _languageNames.Count)
            _index = 0;

        _localization.ChangeLanguage(_languageNames[_index]);
        _localizationView.View(_languageNames[_index]);
        _index++;
    }
}

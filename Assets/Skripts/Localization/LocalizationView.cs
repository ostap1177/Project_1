using TMPro;
using UnityEngine;

public class LocalizationView : MonoBehaviour
{
    private const string EnglishCode = "en";
    private const string RussianCode = "ru";
    private const string TurkishCode = "tr";

    [SerializeField] private TMP_Text _textRU;
    [SerializeField] private TMP_Text _textEN;
    [SerializeField] private TMP_Text _textTR;

    public void View(string languageCode)
    {
        switch (languageCode)
        {
            case (EnglishCode):
                _textRU.enabled = false;
                _textEN.enabled = true;
                _textTR.enabled = false;
                break;
            case (RussianCode):
                _textRU.enabled = true;
                _textEN.enabled = false;
                _textTR.enabled = false;
                break;
            case (TurkishCode):
                _textRU.enabled = false;
                _textEN.enabled = false;
                _textTR.enabled = true;
                break;
        }
    }
}

using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LanguageDefinition : MonoBehaviour
{
    private const string LanguageCode = "LanguageCode";

    public void SaveLanguage(string language)
    {
        PlayerPrefs.SetString(LanguageCode, language);
        PlayerPrefs.Save();
    }

    public string LoadLanguage()
    { 
        return PlayerPrefs.GetString(LanguageCode); 
    }
}

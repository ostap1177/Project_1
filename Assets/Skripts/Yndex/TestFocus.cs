using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.WebUtility;

public class TestFocus : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        Application.focusChanged += OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWed;
    }

    private void OnDisable()
    {
        Application.focusChanged -= OnInBackgroundChangeApp;
        
    }

    private void OnInBackgroundChangeApp(bool inApp)
    {
        MuteAudio(!inApp);
        PauseGame(!inApp);
    }

    private void OnInBackgroundChangeWed(bool isBackground)
    { 
        MuteAudio(isBackground);
        PauseGame(isBackground);
    }

    private void MuteAudio(bool value)
    { 
        _audioSource.volume = value ? 0 : 0.25f;
    }

    private void PauseGame(bool value)
    { 
        Time.timeScale = value ? 0 : 0.25f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoAd : MonoBehaviour
{
    private int _money;

    public void Show() => Agava.YandexGames.VideoAd.Show(OnOpenCallback, /*onRewardadCallback:*/ OnRewardCallback, OnClosedCallback);

    private void OnOpenCallback()
    { 
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
    }

    private void OnRewardCallback() => 
        _money++;

    private void OnClosedCallback()
    {
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
    }
}

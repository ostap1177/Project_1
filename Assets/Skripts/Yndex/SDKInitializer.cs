using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SDKInitializer : MonoBehaviour
{
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

#if UNITY_EDITOR

    private void Start()
    {
        OnInitialized();
    }

#else
    private IEnumerator Start()
    { 
        yield return YandexGamesSdk.Initialize(OnInitialized);
    }
#endif

    private void OnInitialized()
    {
        SceneManager.LoadScene(1);
    }
}

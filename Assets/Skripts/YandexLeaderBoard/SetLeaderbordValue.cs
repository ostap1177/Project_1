using Agava.YandexGames;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetLeaderbordValue : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;

    private const string LeaderBoardName = "Leaderboard";
    private const string AnonymousName = "Anonymous";

    private void OnEnable()
    {
        _scoreCounter.TransferadToYandex += OnFinalizeTime;
    }

    private void OnDisable()
    {
        _scoreCounter.TransferadToYandex -= OnFinalizeTime;
    }

    private void OnFinalizeTime(int scoreTime)
    {
#if UNITY_EDITOR 
        Debug.Log(scoreTime);
#else
        SetPlayerScore(scoreTime);
#endif
    }

    private void SetPlayerScore(int score)
    {
        if (PlayerAccount.IsAuthorized == false)
            return;

        Leaderboard.GetPlayerEntry(LeaderBoardName, (result) =>
        {
            if (result == null || result.score < score)
                Leaderboard.SetScore(LeaderBoardName, score);
        });
    }
}

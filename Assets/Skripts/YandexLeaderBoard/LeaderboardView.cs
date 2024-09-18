using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private LeaderboardElement _leaderboardElementPrefab;

    private List<LeaderboardElement> _spawnedElements = new ();

    public void ConstructLeaderboard(List<LeaderboardPlayer> leaderboardPlayers)
    {
        ClearLeaderboard();
        
        foreach (var player in leaderboardPlayers) 
        {
            LeaderboardElement leaderboardElementInstance = Instantiate(_leaderboardElementPrefab, _container);
            leaderboardElementInstance.Initialize(player.Name, player.Rank, player.Score);
        }
    }

    public void ClearLeaderboard()
    {
        foreach (var element in _spawnedElements)
        { 
            Destroy(element);
        }

        _spawnedElements = new List<LeaderboardElement>();
    }
}

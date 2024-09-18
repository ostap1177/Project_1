using Agava.YandexGames;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Leaderboard = Agava.YandexGames.Leaderboard;


public class LeaderFill : MonoBehaviour
{
    private const string LeaderBoardName = "Leaderboard";
    private const string AnonymousName = "Anonymous";

    private readonly List<LeaderboardPlayer> _leaderPlayers = new();

    [SerializeField] private List<LeaderboardElement> _leaderElements = new();


    private void Start()
    {       
        Debug.Log(_leaderElements.Count);
        Debug.Log(_leaderPlayers.Count);
    }

    /*    public void SetPlayerScore(int score)
        {
            if (PlayerAccount.IsAuthorized == false)
                return;

            Leaderboard.GetPlayerEntry(LeaderBoardName, (result) =>
            {
                if (result == null || result.score < score)
                    Leaderboard.SetScore(LeaderBoardName, score);
            });
        }*/

    public void OpenLeaderBoard()
    {
        Fill();
        ViewBoard();
    }

    private void ViewBoard()
    {
        Debug.Log("_leaderElements -" + _leaderElements.Count);
        Debug.Log("_leaderPlayers -" +_leaderPlayers.Count);

        /* int index = 0;

         foreach (var player in _leaderPlayers) 
         {
             if (index < _leaderElements.Count)
             {
                 Debug.Log("index "+index);
                 _leaderElements[index].Initialize(player.Name, player.Rank, player.Score);
             }
             else 
             {
                 break;
             }

             index++;
         }*/


        Debug.Log("Method ViewBoard");

/*        if (_leaderPlayers.Count > 0)
        {
            Debug.Log("_leaderPlayers.Count - " + _leaderPlayers.Count);

            for (int i = 0; i < _leaderElements.Count; i++)
            {
                Debug.Log("_leaderElements - " + i);

                if (_leaderPlayers[i] == null)
                {
                    Debug.Log($"_leaderPlayers - {i} {_leaderPlayers[i].Name} {_leaderPlayers[i].Rank} {_leaderPlayers[i].Score}");

                    _leaderElements[i].Initialize(_leaderPlayers[i].Name, _leaderPlayers[i].Rank, _leaderPlayers[i].Score);
                }
            }
        }*/

        int index = 0;

        foreach (var player in _leaderPlayers) 
        {
            Debug.Log("_leaderPlayers.Count - " + _leaderPlayers.Count);

            index++;

            Debug.Log("index " + index);

            if (index < _leaderElements.Count)
            {
                Debug.Log($"_leaderPlayers - {index} {player.Name} {player.Rank} {player.Score}");

                _leaderElements[index].Initialize(player.Name, player.Rank, player.Score);
            }
        } 
    }

    private void Fill()
    {
        Debug.Log("Method Fill");

        if (PlayerAccount.IsAuthorized == false)
        {
            Debug.Log("false");

            return;
        }

        //_leaderPlayers.Clear();

        Leaderboard.GetEntries(LeaderBoardName, (result) =>
        {
            Debug.Log("GetEntries - " + result.entries.Length);

            foreach (var entry in result.entries) 
            {
                int rank = entry.rank;
                int score = entry.score;
                string name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = AnonymousName;

                LeaderboardPlayer leaderboardPlayer = new LeaderboardPlayer(rank, name, score);

                Debug.Log($"_leaderPlayer - fill {leaderboardPlayer.Name} {leaderboardPlayer.Rank} {leaderboardPlayer.Score}");


                _leaderPlayers.Add(leaderboardPlayer);
            }
/*
            for (int i = 0; i < _leaderElements.Count; i++)
            {
                Debug.Log("HUY");
                int score = result.entries[i].score;
                string name = result.entries[i].player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = AnonymousName;

                _leaderPlayers.Add(new LeaderPlayer(name, score));
            }*/
/*
            foreach (var entry in result.entries)
            {
                int score = entry.score;
                string name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = AnonymousName;

                _leaderboardPlayers.Add(new LeaderPlayer(name, score));
            }*/
        });
    }
}

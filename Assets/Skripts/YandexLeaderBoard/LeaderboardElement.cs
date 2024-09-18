using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private TMP_Text _playerRank;
    [SerializeField] private TMP_Text _playerScore;

    public void Initialize(string name, int rank, int score)
    { 
        _playerName.text = name;   
        _playerRank.text = rank.ToString();
        _playerScore.text = Time(score);   
    }

    private string Time(int score)
    {
        int time = score/1000;

        //float hours = 0;
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
/*
        if (minutes > 60)
        { 
            hours = Mathf.FloorToInt(minutes / 60);
            minutes = Mathf.FloorToInt(minutes % 60);
        }

        float[] array = new[] {hours, minutes, seconds };

        return  string.Format("{0:00} : {1:00} : {2:00}", array);*/

        return string.Format("{0:00} : {1:00}", minutes, seconds);

    }
}

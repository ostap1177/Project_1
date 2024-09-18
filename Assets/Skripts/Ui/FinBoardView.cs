using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinBoardView : MonoBehaviour
{
    [SerializeField] private UiBoard _uiBoard;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _bestTime;
    [SerializeField] private TMP_Text _bestScore;

    private void OnEnable()
    {
        _scoreCounter.FinalizeTime += OnFinalizeTime;
    }

    private void OnDisable()
    {
        _scoreCounter.FinalizeTime += OnFinalizeTime;
    }

    private void OnFinalizeTime(float minutes, float seconds, int bestScore)
    {
        /*float hours = 0;

        if (minutes > 60)
        {
            hours = Mathf.FloorToInt(minutes / 60);
            minutes = Mathf.FloorToInt(minutes % 60);
        }

        float[] array = new float [3] { hours, minutes, seconds };

        Debug.Log(string.Format("{0:00} : {1:00} : {2:00}", array));

        _bestTime.text = string.Format("{0:00} : {1:00} : {2:00}", array);*/


        
        _bestTime.text = string.Format("{00:00}:{01:00}", minutes, seconds);
        _bestScore.text = bestScore.ToString();
    }
}

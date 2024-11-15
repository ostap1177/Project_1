using Ui;
using UnityEngine;

public class FinalButton : ParentButtons
{
    [Space(10)]
    [SerializeField] private ScoreCounter _scoreCounter;
    protected override void Click()
    {
        _scoreCounter.FinalCalculateScore();
    }
}

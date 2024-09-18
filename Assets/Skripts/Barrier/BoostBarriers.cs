using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBarriers : MonoBehaviour
{
    [SerializeField] private float _socondTime = 5f;
    [SerializeField] private int _boostMultiplier = 2;
    [SerializeField] private Switcher _switcher;
    [SerializeField] private Timer _timer;
    [SerializeField] private ButtonClicker _buttonClicker;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private CostView _costView;
    [SerializeField] private int _boostCost = 900;
    [SerializeField] private float _costMultiplier = 2.2f;

    private int _normalMultiplaer = 1;

    private void OnEnable()
    {
        _buttonClicker.BoostedBarriers += OnBoostedBarriers;
        _timer.EndTime += OnEndTime;
    }

    private void OnDisable()
    {
        _buttonClicker.BoostedBarriers -= OnBoostedBarriers;
        _timer.EndTime -= OnEndTime;
    }

    private void OnBoostedBarriers()
    {
        if (_scoreCounter.TryRemovePoint(_boostCost))
        {
            Boost();
            ChangePrice();
        }
    }

    private void Awake()
    {
        _costView.SetText(_boostCost);
    }

    private void OnEndTime()
    {
        _costView.EnableText(true);
        _switcher.SetSpeedActiveBarriers(_normalMultiplaer);
    }

    private void Boost()
    {
        _costView.EnableText(false);
        _timer.CountingDown(_socondTime);
        _switcher.SetSpeedActiveBarriers(_boostMultiplier);
    }

    private void ChangePrice()
    {
        float tempValue = (float)_boostCost * _costMultiplier;

        _boostCost = (int)tempValue;
        _costView.SetText(_boostCost);
    }
}

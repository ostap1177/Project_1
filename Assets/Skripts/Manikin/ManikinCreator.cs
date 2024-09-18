using System.Collections.Generic;
using UnityEngine;

public class ManikinCreator : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private ButtonClicker _playEventer;
    [SerializeField] private CostView _costView;
    [SerializeField] private int _manikinCost = 100;
    [SerializeField] private float _costMultiplier = 1.1f;
    [SerializeField] private Manikin _manikinPrefab;
    [SerializeField] private float _leftLimit;
    [SerializeField] private float _rightLimit;

    private Transform _transform;

    public int ManikinCost => _manikinCost;

    private void OnEnable()
    {
        _playEventer.DropedManikin += OnDropedManikin;
    }

    private void OnDisable()
    {
        _playEventer.DropedManikin -= OnDropedManikin;
    }

    private void Awake()
    {
        _transform = transform;
        _costView.SetText(_manikinCost);
    }

    private void Create()
    { 
        float xPosition = Random.Range(_leftLimit, _rightLimit);
        Vector3 position = new Vector3(xPosition, _transform.position.y, _transform.position.z);

        Instantiate(_manikinPrefab.gameObject, position, Quaternion.identity);
    }

    private void OnDropedManikin()
    {
        if (_scoreCounter.TryRemovePoint(_manikinCost))
        { 
            Create();
            ChangePrice();
        }
    }

    private void ChangePrice()
    {
        float tempValue = (float)_manikinCost * _costMultiplier;

         _manikinCost = (int)tempValue;
        _costView.SetText(_manikinCost);
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private ButtonClicker _playEvent;
    [SerializeField] private CostView _costView;
    [SerializeField] private int _barrierCost;
    [SerializeField] private float _costMultiplier = 2.2f;
    [SerializeField] private int _countBarriersStart = 6;
    [SerializeField] private Barriers _barriersPrefab;

    private List<BarriersPlace> _places = new List<BarriersPlace>();
    private List<Barriers> _activeBarriers = new List<Barriers>();
    private Transform _transform;

    public int BarrierCost => _barrierCost;

    private void OnEnable()
    {
        _playEvent.BuildedBarriers += OnBuildedBarriers;
    }

    private void OnDisable()
    {
        _playEvent.BuildedBarriers -= OnBuildedBarriers;
    }

    private void Awake()
    {
        _transform = transform;
        _costView.SetText(_barrierCost); 

        foreach (Transform child in _transform)
        {
            if (child.TryGetComponent(out BarriersPlace barriersPlace))
            {
                _places.Add(barriersPlace);
            }
        }

        if (_countBarriersStart > _places.Count)
        {
            _countBarriersStart=_places.Count;
        }
    }

    private void Start()
    {
        for (int i = 0; i < _countBarriersStart; i++)
        {
            InstantiateBarriers();
        }
    }

    public void SetSpeedActiveBarriers(int speed)
    {
        foreach (Barriers barriers in _activeBarriers)
        {
            if (barriers != null)
            {
                barriers.SetSpeed(speed);
            }
        }
    }

    public void RemoveActiveBarriers(Barriers barriers)
    {
        _activeBarriers.Remove(barriers);
    }

    private void InstantiateBarriers()
    {
        if (_places.Count(place => place.IsFilled == false) > 0)
        {
            BarriersPlace tempPlace = _places.FirstOrDefault(place => place.IsFilled == false);
            Barriers barriers = Instantiate(_barriersPrefab, tempPlace.transform.position, Quaternion.identity, _transform);

            tempPlace.SetBarriers(barriers);
            _activeBarriers.Add(barriers);
        }
    }

    private void OnBuildedBarriers()
    {
        if (_scoreCounter.TryRemovePoint(_barrierCost))
        {
            InstantiateBarriers();
            ChangePrice();
        }
    }

    private void ChangePrice()
    {
        float tempValue = (float)_barrierCost * _costMultiplier;

        _barrierCost = (int)tempValue;
        _costView.SetText(_barrierCost);
    }
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    [SerializeField] private int _countBarriersStart = 6;
    [SerializeField] private Barriers _barriersPrefab;

    private List <BarriersPlace> _barriersPlaces = new List<BarriersPlace>();

    private Transform _transform;
    private int _startIndexcBarrier = 0;

    private void Awake()
    {
        _transform = transform;

        _barriersPlaces = CollectBarriersPlace();
        
    }

    private void Start()
    {
        ActivateBarriers();
    }

/*    public void CreateBarriers()
    {
        BarriersPlace place = _barriersPlaces.FirstOrDefault(p => p.IsFilled == true);
        Instantiate(_barriersPrefab, place.transform);
        place.FillPlace();
    }*/

    private void ActivateBarriers()
    {
        if (_countBarriersStart > _barriersPlaces.Count)
        { 
            _countBarriersStart = _barriersPlaces.Count;
        }

        for (int i = _countBarriersStart; i > 0; i--)
        {
            _barriersPlaces.FirstOrDefault(p => p.IsFilled == false).FillPlace(_startIndexcBarrier);
        }
    }

    private List<BarriersPlace> CollectBarriersPlace()
    {
        List <BarriersPlace> temp = new List<BarriersPlace>();

        foreach (Transform child in _transform)
        {
            if (child.TryGetComponent(out BarriersPlace barriersPlace))
            { 
                temp.Add(barriersPlace);
            }
        }

        return temp;
    }
}
